<?php
/**
 * Controle de fotos
 *
 * @name Sistema_FotosController
 * @author Nome
 * @package sistema_controllers
 * @version $Id$
 */
class Redesocial_FotoController extends Axs_Controller_Action
{

	/**
	 * Objeto do modelo Sistemafotos
	 *
	 * @name $fotos
	 * @access protected
	 * @var object
	 */
	protected $fotos;

	/**
	 * Método init da classe.
	 *
	 * @name init
	 * @access public
	 * @return void
	 */
	function init()
	{
		$this->initView();
		$this->fotos = new Foto;

		// Seta valores pré-determinados para os campos da view
		$this->carregaValoresView();
	}

	/**
	 * Método que realiza a verificação de login do usuário.
	 *
	 * @name preDispatch
	 * @access public
	 * @return void
	 */
	function preDispatch()
	{
		Axs_ACL::isIdentity();
	}

	/**
	 * Método responsável pelo carregamento de todos os campos combobox, radio, checkbox e outros.
	 *
	 * @name carregaValoresView
	 * @access public
	 * @return void
	 */
	function carregaValoresView()
	{
		// Carrega a descrição dos campos
		$this->view->descricaoCampos = $this->fotos->descriptionFields;
	}

	/**
	    * Método principal da classe.
	    *
	    * @name indexAction
	    * @access public
	    * @return void
	    */
	function indexAction()
	{
		// Seta o action da view e o Título da página
		$this->view->action = 'index';
		$this->view->title = 'Fotos';

		if($this->getRequest()->getParam('mensagem')){
			$this->view->mensagens = array($this->getRequest()->getParam('mensagem'));
		}

		$auth = Zend_Auth::getInstance();
		$user = $auth->getStorage()->read();

		$this->view->dados = $this->fotos->getFotos($user->membroId);

		$this->render();
	}

	/**
	 * Retorna a imagem no tamanho grade
	 *
	 * @name fotolargeAction
	 * @access public
	 * @return void
	 */
	function fotolargeAction()
	{
		debugbreak();
		$imagem  = @file_get_contents(base64_decode($this->getRequest()->getParam('foto')));
		$html = "
			<div id\"fotoLarge\">
				<img src=\"data:image/gif;base64,".base64_encode($imagem)."\" style = \" width: 40.625em;\"  />
			</div>
			";
		echo $html;
		$this->_helper->viewRenderer->setNoRender();
	}

	/**
	    * Método que adciona o avatar na tela.
	    *
	    * @name getavatarAction
	    * @access public
	    * @return void
	    */
	function getavatarAction(){

		$dados = $this->_request->getParams();

		if($dados == null || !@$dados['idMembro'])
		{
			$auth = Zend_Auth::getInstance();
			$user = $auth->getStorage()->read();
			$dados['idMembro'] = $user->idMembro;
		}
		$dados = $this->fotos->getAvatar($dados['idMembro']);
		$this->view->dados = $dados;
		$this->render('avatar');
	}

	/**
	 * Método responsável pela operação de inserção de dados no banco.
	 *
	 * @name addAction
	 * @access public
	 * @return void
	 */
	function addAction()
	{
		// Seta o action da view e o Título da página
		$this->view->action = 'add';
		$this->view->title = 'Inserir de foto';

		// Verifica se a chamada do controller foi feita via POST
		if($this->_request->isPost()){

			$dados = $this->fotos->getCamposUteis($this->_request->getParams());

			Zend_Loader::loadClass('Zend_File_Transfer');
			$upload = new Zend_File_Transfer();

			// Set a file size with 20000 bytes
			$upload->addValidator('Size', true, 15000000)
				->addValidator('Extension', false, 'jpg,png,gif');

			// Se todas as validações não contiverem erros
			if($upload->isValid()){

				$auth = Zend_Auth::getInstance();
				$user = $auth->getStorage()->read();

				$path = "{$_SERVER['DOCUMENT_ROOT']}/public/upload/{$user->membroId}_{$user->membroNickName}";
				@mkdir($path, 0777, true);
				$upload->setDestination($path);

				$dados['fotoId'] = null;
				$dados['fotoPath'] = $path;
				$dados['membroId'] = $user->membroId;
				$dados['fotoName'] = str_ireplace($path,"",$upload->getFileName());

				// Inicia a transação
				$this->fotos->getAdapter()->beginTransaction();

				// Realiza a inserção dos dados na tabela validando novamente
				$result = $this->fotos->insertValid($dados);

				if($result){
					$dados['fotoId'] = $result;
					$this->fotos->getAdapter()->commit();
					$upload->receive();

					$path = "{$_SERVER['DOCUMENT_ROOT']}/public/upload/{$user->membroId}_{$user->membroNickName}/pasta_thumbs";
					@mkdir($path, 0755, true);
					$upload->setDestination($path);
					$this->resizeImage($upload,80,80);

					// Redireciona para a index
					$this->_redirect("/fotos/index/mensagem/Foto incluída com sucesso.");

				} else {
					$this->fotos->getAdapter()->rollback();

					// Redireciona para a index
					$this->_redirect("/fotos/fotos/mensagem/Ocorreu um erro ao tentar inserir o Foto.");
				}
			} else {

				// Captura os erros e envia para a tela
				$this->view->errors = $upload->getMessages();

				// Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->fotos->getMensagens();
			}
			// Retorna os dados para a tela
			$this->view->assign($dados);
		}

		// Seta os botões à serem utilizados na view
		$this->view->botao_submit = array();

		$this->view->botao_submit['Salvar']      = array(
			'nome' => 'acao',
			'tipo' => 'submit'
			);

		$this->render();
	}

	/**
	 * Método responsável pela operação de atualização de dados no banco.
	 *
	 * @name editAction
	 * @access public
	 * @return void
	 */
	function avatarAction()
	{
		$dados = $this->fotos->getCamposUteis($this->_request->getParams());
		$upload = new Zend_File_Transfer();

		// Set a file size with 2MB
		$upload->addValidator('Size', true, 2000000);

		// Se todas as validações não contiverem erros
		if($upload->isValid()){
			
			$auth = Zend_Auth::getInstance();
			$user = $auth->getStorage()->read();
			
			$path = "{$_SERVER['DOCUMENT_ROOT']}/zend/public/upload/{$user->idMembro}/pasta_thumbs/avatar";
			@mkdir($path, 0755, true);
			$this->deleteFiles($path);
			$upload->setDestination($path);

			// Inicia a transação
			$this->fotos->getAdapter()->beginTransaction();

			$dados['idFoto'] =null;
			$dados['pathFoto'] = $path;
			$dados['idMembro'] = $user->idMembro;
			$dados['tipoFoto'] = "";
			$dados['nameFoto'] = str_ireplace($path,"",$upload->getFileName());
			$dados['isAvatarFoto'] = 1;
			$dados['legendaFoto'] = 'Avatar';

			$result = $this->fotos->getAvatar($dados['idMembro']);
			if($result == null){
				$result = $this->fotos->insert($dados);
			}
			else{

				$dados['idFoto'] = $result['idFoto'];

				// recupera a clausula where
				$where = $this->fotos->getWhere($result, 0);

				// Realiza a inserção dos dados na tabela validando novamente
				$result = $this->fotos->update($dados,$where);
			}

			if($result){
				$this->resizeImage($upload,170,170);
				$this->fotos->getAdapter()->commit();
				echo("Foto enviada!");
			} else {
				$this->fotos->getAdapter()->rollback();
			}
		} else {
			echo("Falha ao enviar");
		}
		$this->_helper->viewRenderer->setNoRender();
	}

	/**
	 * Método responsável pela operação de exclusão de dados no banco.
	 *
	 * @name deleteAction
	 * @access public
	 * @return void
	 */
	function deleteAction()
	{
		// Recupera os os campos úteis passados pela requisição
		$camposUteis = $this->fotos->getCamposUteis($this->_request->getParams());

		if($this->fotos->deleteFoto($camposUteis['fotoId'])){
			echo "Foto excluida.";
		} else {
			echo "Erro ao excluir a foto.";
		}
		$this->_helper->viewRenderer->setNoRender();
	}


	public function editlegendaAction()
	{
		// Recupera os os campos úteis passados pela requisição
		$camposUteis = $this->fotos->getCamposUteis($this->_request->getParams());

		if($this->fotos->editLegenda($camposUteis['fotoId'],$camposUteis['fotoLegenda'])){
			echo "fotoLegenda alterada.";
		} else {
			echo "Erro ao alterar a legenda.";
		}
		$this->_helper->viewRenderer->setNoRender();
	}

	/**
	 * Método responsável por redimensionar a imagem.
	 *
	 * @name addAction
	 * @access public
	 * @return void
	 */
	public function resizeImage($upload,$width,$height)
	{
		// Returns all known internal file information
		$fileInfo = $upload->getFileInfo();

		$filename = $fileInfo['pathFoto']['name'];
		$fileTempName = $fileInfo['pathFoto']['tmp_name'];
		$fotoPath = $fileInfo['pathFoto']['destination'];

		$size=getimagesize($fileTempName);
		switch($size["mime"]){
			case "image/jpeg":
				$img = imagecreatefromjpeg($fileTempName); //jpeg file
				break;
			case "image/gif":
				$img = imagecreatefromgif($fileTempName); //gif file
				break;
			case "image/png":
				$img = imagecreatefrompng($fileTempName); //png file
				break;
			default:
				$img=false;
				break;
		}
		if($img)
		{
			$imgNova = imagecreatetruecolor($width,$height);
			imagecopyresampled($imgNova,$img,0,0 ,0,0,$width,$height,imagesx($img),imagesy($img));
			@mkdir($fotoPath, 0755, true);
			imagejpeg($imgNova,$fotoPath."/".$filename, 95);
		}
	}


	public function deleteFiles($path)
	{
		if(is_dir($path))
		{
			if($handle = opendir($path))
			{
				while(($file = readdir($handle)) !== false)
				{
					if($file != '.' && $file != '..')
					{
						unlink($path."/".$file);
					}
				}
			}
		}
		return 0;
	}
}

?>
