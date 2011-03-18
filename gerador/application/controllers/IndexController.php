<?php
/**
 * Controller Incial do sistema
 *
 * @name IndexController.php
 * @author Alexis Moura 1/4/2009 10:39:36
 * @package Controller
 * @version $Id$
 */
class IndexController extends Zend_Controller_Action {


    /**
     * Descrição dos campos a serem validados
     *
     * @name $_descricaoCampos
     * @access protected
     * @var array
     */
    protected $_descricaoCampos = array('cod_ent' => 'Entidade',
        							    'username' => 'Matrícula',
        								'password' => 'Senha');
	protected $conexao;
    function init()
    {

		$this->initView();
        $this->view->baseUrl = $this->_request->getBaseUrl();
        Zend_Loader::loadClass('Entidade');
        $this->view->user = Zend_Auth::getInstance()->getIdentity();
    }


    function preDispatch()
    {
//        $auth = Zend_Auth::getInstance();
//        if (!$auth->hasIdentity()) {
//            $this->_redirect('auth/login');
//        }
    }


    function indexAction()
    {
		//Seta o action da view e o Título da página
        $this->view->action = 'index';
        $this->view->title = 'Selecione o banco de dados';
		debugbreak();
		if ($this->_request->isPost()) {


			Zend_Loader::loadClass('Entidade');
			//debugbreak();
			// Recupera os dados do formulário postado pelo usuário
            $data = $this->getRequest()->getParams();
			$teste = true;
            try{
				$this->conexao  = @mssql_connect($data["host"],$data["usuario"],$data["senha"]);
				@mssql_select_db ( $data["banco"], $this->conexao );
			}catch(Exception $e)
			{
				$teste = false;
			}
			if($teste){
				$sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
				$result = @mssql_query ( $sql, $this->conexao );

				for ($i = 0; $i < mssql_num_rows( $result ); ++$i)
				{
					$line = mssql_fetch_row($result);
					$linhas[] = $line[0];
			        $this->view->action = 'table';
        			$this->view->title = 'Selecione a tabela';
				}
				$this->view->assign(array("dados"=>$linhas));
			}
			$this->view->host = $data["host"];
			$this->view->banco = $data["banco"];
			$this->view->usuario = $data["usuario"];
			$this->view->senha = $data["senha"];
		}else{

			$this->view->host = 'CRONOS\SHIVA';
			$this->view->banco = 'DIADEMA_IV';
			$this->view->usuario = 'sa';
			$this->view->senha = 'dolar$';
		}

		// seta os botões serem utilizados na view
        $this->view->botao_submit = array(
                                            'Proximo' => array(
																'nome' => 'acao',
				                                                'tipo' => 'submit'
				                                               ),
                                            );

		$this->render();
    }

	function tableAction()
    {

		debugbreak();
		$linhas = array();
		$fonte = array();

		Zend_Loader::loadClass('Gerador');
		$Gerador = new Gerador();

		// Recupera os dados do formulário postado pelo usuário
		$data = $this->getRequest()->getParams();

		$teste = true;
        try{
			$this->conexao  = @mssql_connect($data["host"],$data["usuario"],$data["senha"]);
			@mssql_select_db ( $data["banco"], $this->conexao );
		}catch(Exception $e)
		{
			$teste = false;
		}
		if($teste)
		{
			$linhas["projeto"] = $data["projeto"];
			$linhas["host"] = $data["host"];
			$linhas["usuario"] = $data["usuario"];
			$linhas["senha"] = $data["senha"];
			$linhas["banco"] = $data["banco"];

			foreach($data["tabela"] as $key => $tabela ){

				if($data["data"][$key]==1)
				{
					$SQL = <<<SQL
							SELECT
								C.COLUMN_NAME,
								CASE
									 -- TIPO bigint
									 WHEN C.DATA_TYPE = 'bigint' AND C.IS_NULLABLE = 'NO'
									 THEN 'decimal'
									 WHEN C.DATA_TYPE = 'bigint' AND C.IS_NULLABLE = 'YES'
									 THEN 'decimal?'

									 -- TIPO bit
									 WHEN C.DATA_TYPE = 'bit' AND C.IS_NULLABLE = 'NO'
									 THEN 'bool'
									 WHEN C.DATA_TYPE = 'bit' AND C.IS_NULLABLE = 'YES'
									 THEN 'bool?'

									 -- TIPO decimal
									 WHEN C.DATA_TYPE = 'decimal' AND C.IS_NULLABLE = 'NO'
									 THEN 'decimal'
									 WHEN C.DATA_TYPE = 'decimal' AND C.IS_NULLABLE = 'YES'
									 THEN 'decimal?'

									 -- TIPO int
									 WHEN C.DATA_TYPE = 'int' AND C.IS_NULLABLE = 'NO'
									 THEN 'int'
									 WHEN C.DATA_TYPE = 'int' AND C.IS_NULLABLE = 'YES'
									 THEN 'int?'

									 -- TIPO money
									 WHEN C.DATA_TYPE = 'money' AND C.IS_NULLABLE = 'NO'
									 THEN 'double'
									 WHEN C.DATA_TYPE = 'money' AND C.IS_NULLABLE = 'YES'
									 THEN 'double?'

									 -- TIPO numeric
									 WHEN C.DATA_TYPE = 'numeric' AND C.IS_NULLABLE = 'NO'
									 THEN 'double'
									 WHEN C.DATA_TYPE = 'numeric' AND C.IS_NULLABLE = 'YES'
									 THEN 'double?'

									 -- TIPO real
									 WHEN C.DATA_TYPE = 'real' AND C.IS_NULLABLE = 'NO'
									 THEN 'double'
									 WHEN C.DATA_TYPE = 'real' AND C.IS_NULLABLE = 'YES'
									 THEN 'double?'

									 -- TIPO smallint
									 WHEN C.DATA_TYPE = 'smallint' AND C.IS_NULLABLE = 'NO'
									 THEN 'int'
									 WHEN C.DATA_TYPE = 'smallint' AND C.IS_NULLABLE = 'YES'
									 THEN 'int?'

									 -- TIPO smallmoney
									 WHEN C.DATA_TYPE = 'smallmoney' AND C.IS_NULLABLE = 'NO'
									 THEN 'decimal'
									 WHEN C.DATA_TYPE = 'smallmoney' AND C.IS_NULLABLE = 'YES'
									 THEN 'decimal?'

									 -- TIPO tinyint
									 WHEN C.DATA_TYPE = 'tinyint' AND C.IS_NULLABLE = 'NO'
									 THEN 'int'
									 WHEN C.DATA_TYPE = 'tinyint' AND C.IS_NULLABLE = 'YES'
									 THEN 'int?'

									 -- TIPO float
									 WHEN C.DATA_TYPE = 'float' AND C.IS_NULLABLE = 'NO'
									 THEN 'float'
									 WHEN C.DATA_TYPE = 'float' AND C.IS_NULLABLE = 'YES'
									 THEN 'float?'

									 -- TIPO date
									 WHEN
										(
											C.DATA_TYPE = 'date' OR
											C.DATA_TYPE = 'datetime2' OR
											C.DATA_TYPE = 'datetime' OR
											C.DATA_TYPE = 'datetimeoffset' OR
											C.DATA_TYPE = 'smalldatetime' OR
											C.DATA_TYPE = 'time'
										) AND C.IS_NULLABLE = 'NO'
									 THEN 'DateTime'
									 WHEN
										(
											C.DATA_TYPE = 'date' OR
											C.DATA_TYPE = 'datetime2' OR
											C.DATA_TYPE = 'datetime' OR
											C.DATA_TYPE = 'datetimeoffset' OR
											C.DATA_TYPE = 'smalldatetime' OR
											C.DATA_TYPE = 'time'
										) AND C.IS_NULLABLE = 'YES'
									 THEN 'DateTime?'

									 ELSE 'string'
								END AS TIPO,
								C.CHARACTER_MAXIMUM_LENGTH,
								CASE WHEN (SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME = '{$tabela}' AND COLUMN_NAME = C.COLUMN_NAME) IS NOT NULL
									 THEN 1
									 ELSE 0
								END AS PRIMARIA
							FROM INFORMATION_SCHEMA.COLUMNS C
							LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON CU.COLUMN_NAME = C.COLUMN_NAME
							WHERE C.TABLE_NAME = '{$tabela}'
SQL;
					$result = @mssql_query ( $SQL, $this->conexao );

					for ($i = 0; $i < mssql_num_rows( $result ); ++$i)
					{
						$line = mssql_fetch_row($result);
						$linhas["classe"][$tabela] = $data["classe"][$key];
						$linhas["tabela"][$tabela][$line[0]] = array(
																		"nome" =>$line[0],
																		"tipo" =>$line[1],
																		"tamanho" =>$line[2],
																		"primaria" =>$line[3],
										   							  );

					}
				}
			}
			$fonte= $Gerador->GeraFonte($linhas,array("web"=>$data["projetoWeb"]));
			$zip = $this->geraZipData($fonte,$data);
			$Buffer = $zip->zipped_file();
	        header('Content-type: text/richtext; charset=UTF-8');
	        header('Content-Length: ' . strlen($Buffer));
	        header('Content-Disposition: attachment; filename="templates.zip"');
	        echo($Buffer);
	        die();
		}
    }

	public function geraZipData($fonte,$data){

		Zend_Loader::loadClass('Zipfile');
		$Zipfile = new Zipfile();

		// Diretorio Raiz
		$dirRaiz = $data["projeto"];
		$dirData = $data["projeto"]."_DATA";
		$dirWeb  = $data["projeto"]."_WEB";

		$Zipfile->create_dir($dirRaiz."/".$dirData."/");
		$Zipfile->create_file($fonte["Project"],$dirRaiz."/".$dirData."/".$data["projeto"]."_DATA.csproj");
		$Zipfile->create_file($fonte["AppConfig"],$dirRaiz."/".$dirData."/"."app.config");

		$Zipfile->create_dir($dirRaiz."/".$dirData."/Properties/");
		$Zipfile->create_file($fonte["Assembly"],$dirRaiz."/".$dirData."/Properties/AssemblyInfo.cs");

		$Zipfile->create_dir($dirRaiz."/".$dirData."/Model/");
		foreach($fonte["Model"] as $nomeArquivo => $codigoFonte ){

			$Zipfile->create_file($codigoFonte,$dirRaiz."/".$dirData."/Model/".$nomeArquivo);
		}

		$Zipfile->create_dir($dirRaiz."/".$dirData."/DAL/");
		foreach($fonte["DAO"] as $nomeArquivo => $codigoFonte ){

			$Zipfile->create_file($codigoFonte,$dirRaiz."/".$dirData."/DAL/".$nomeArquivo);
		}
		$Zipfile->create_dir($dirRaiz."/".$dirData."/BFL/");
		foreach($fonte["BFL"] as $nomeArquivo => $codigoFonte ){

			$Zipfile->create_file($codigoFonte,$dirRaiz."/".$dirData."/BFL/".$nomeArquivo);
		}

		if($data["projetoWeb"]==1)
		{
			$Zipfile->create_dir($dirRaiz."/".$dirWeb."/");
			$Zipfile->create_file($fonte["WEB"]["masterpage"],$dirRaiz."/".$dirWeb."/MasterPage.master");
			$Zipfile->create_file($fonte["WEB"]["masterpagecs"],$dirRaiz."/".$dirWeb."/MasterPage.master.cs");
			$Zipfile->create_file($fonte["WEB"]["webConfig"],$dirRaiz."/".$dirWeb."/web.config");
			$Zipfile->create_file($fonte["WEB"]["default"],$dirRaiz."/".$dirWeb."/Default.aspx");

			$Zipfile->create_dir($dirRaiz."/".$dirWeb."/Style/");
			$Zipfile->create_file("  ",$dirRaiz."/".$dirWeb."/Style/Global.css");

			$Zipfile->create_dir($dirRaiz."/".$dirWeb."/Cadastros/");
			foreach($fonte["WEB"]["cadastros"] as $nomeArquivo => $codigoFonte ){

				$Zipfile->create_file($codigoFonte,$dirRaiz."/".$dirWeb."/Cadastros/".$nomeArquivo);
			}
		}

		$Zipfile->create_dir($dirRaiz."/".$dirData."/Contribuicoes/");
		$fileGDA = str_replace("index.php","application/controllers/GDA.dll",$_SERVER["SCRIPT_FILENAME"]);
		$GDA = file_get_contents($fileGDA);
		$Zipfile->create_file($GDA,$dirRaiz."/".$dirData."/Contribuicoes/GDA.dll");
		return $Zipfile;
	}
}
