<?php
/**
 * Helper de constru��o do filtro de pesquisa
 * 
 * @name  
 * @author
 * @package 
 * @version
 */
class Zend_View_Helper_Pesquisa {
	/**
	* Vari�vel utilizada para cria��o do filtro da tela de pesquisa.
	* 
	* @name $filtro
	* @access public 
	* @var string 
	*/
	public $filtro;

	/**
	* Campos da tabela para exibi��o do resultado.
	* 
	* @name $campos
	* @access public 
	* @var string 
	*/
	public $campos;

	/**
	 * Vari�vel para receber o objeto da view
	 * 
	 * @name $view 
	 * @access public
	 * @var object
	 */
	public $view;

	/**
	 * Fun��o para carregar o objeto da view dentro do helper
	 * 
	 * @name $view 
	 * @param Zend_View_Interface setView
	 * @access public
	 * @return void
	 */
	public function setView(Zend_View_Interface $view)
	{
		$this->view = $view;
	} 
	
	/**
	* M�todo principal do Helper de pesquisa, recebe as configura��es do filtro, dos campos da tabela.
	* 
	* @name Pesquisa
	* @param array $filtroPesquisa 
	* <code>
	* array(
	*            nome_do_campo => array( 
	*                                   tipo_campo         => tipo_do_campo //string
	*                                   tipo_dado          => tipo_do_dado  //string
	*                                   descricao          => descricao_do_campo // string
	*                                   escolhaObrigatorio => escolhaObrigatorio // default(false) mostra a primeira op��o do select vazio ou n�o.
	*                                   opcoes             => array( 
	*                                                               chave => valor// array associativo
	*                                                              )
	*                                   ) 
	*             )
	* 
	* Tipos para:
	* tipo_campo => select, text, radio, checkbox, date
	* tipo_dado => numerico, string, options
	* </code>
	* @param  array $camposPesquisa
	* <code>
	* array(
	*            nome_do_campo => array( 
	*                                   descri��o cabe�alho,
	*                                   alinhamento
	*             )
	* 
	* Tipos de alinhamento => left, center, right
	* </code>
	* @access public
	* @return void
	*/
	public function Pesquisa($filtrosPesquisa,$camposPesquisa,$linkRegistros)
	{
		$this->filtroPesquisa($filtrosPesquisa); 
		$this->campoPesquisa($camposPesquisa,$linkRegistros);
		return;
	} 

	/**
	* Fun��o para constru��o do filtro de pesquisa
	* 
	* @name $filtroPesquisa
	* @param array $filtroPesquisa 
	* <code>
	* array(
	*            nome_do_campo => array( 
	*                                   tipo_campo         => tipo_do_campo //string
	*                                   tipo_dado          => tipo_do_dado  //string
	*                                   descricao          => descricao_do_campo // string
	*                                   escolhaObrigatorio => escolhaObrigatorio // default(false) mostra a primeira op��o do select vazio ou n�o.
	*                                   opcoes             => array( 
	*                                                               chave => valor// array associativo
	*                                                              )
	*                                   ) 
	*             )
	* 
	* Tipos para:
	* tipo_campo => select, text, radio, checkbox, date
	* tipo_dado => numerico, string, options
	* </code>
	* @access 
	* @return 
	*/
	public function filtroPesquisa($filtroPesquisa)
	{ 
		// operadores l�gicos
		$_operadoresLogico = array('OPL_IGUAL' => 'igual a',
			'OPL_DIFERENTE' => 'diferente de',
			'OPL_MAIOR' => 'maior que',
			'OPL_MENOR' => 'menor que',
			'OPL_MAIOR_IGUAL' => 'maior ou igual a',
			'OPL_MENOR_IGUAL' => 'menor ou igual a',
			'OPL_ENTRE' => 'com valores entre',
			'OPL_VAZIO' => 'est� vazio',
			'OPL_NAO_VAZIO' => 'n�o est� vazio',
			'OPL_VALOR_LISTA' => 'valores da lista',
			'OPL_COMECANDO' => 'come�ando com',
			'OPL_TERMINANDO' => 'terminando com',
			'OPL_QUALQUER_LUGAR' => 'em qualquer lugar'
			); 
		// grupos de tipo de dados para utiliza��o dos operadores l�gicos
		$_grupoOperadoresLogico = array('string' => array('OPL_IGUAL' => 'igual a',
			'OPL_DIFERENTE' => 'diferente de',
			'OPL_VAZIO' => 'est� vazio',
			'OPL_NAO_VAZIO' => 'n�o est� vazio',
			'OPL_COMECANDO' => 'come�ando com',
			'OPL_TERMINANDO' => 'terminando com',
			'OPL_QUALQUER_LUGAR' => 'em qualquer lugar'
			),
				'numerico' => array('OPL_IGUAL' => 'igual a',
					'OPL_DIFERENTE' => 'diferente de',
					'OPL_MAIOR' => 'maior que',
					'OPL_MENOR' => 'menor que',
					'OPL_MAIOR_IGUAL' => 'maior ou igual a',
					'OPL_MENOR_IGUAL' => 'menor ou igual a',
					'OPL_ENTRE' => 'com valores entre',
					'OPL_VAZIO' => 'est� vazio',
					'OPL_NAO_VAZIO' => 'n�o est� vazio',
					'OPL_VALOR_LISTA' => 'valores da lista'
					),
				'options' => array('OPL_IGUAL' => 'igual a',
					'OPL_DIFERENTE' => 'diferente de',
					'OPL_VAZIO' => 'est� vazio',
					'OPL_NAO_VAZIO' => 'n�o est� vazio'
					)
				); 
		// constru��o da tabela em html para o filtro, para posterior utiliza��o na view
		//$content .= "<form name='' action='{$this->view->baseUrl}/{$this->request->getControllerName()}/pesquisa/' method='post'>";
		$content = "\n<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"97%\">\n";
		$content .= "<tbody>\n"; 
		// contador para cores
		$contador = 0;
		// percorre o array de dados passado para constru��o do filtro de pesquisa
		foreach($filtroPesquisa as $nome_do_campo => &$atributos_do_campo) {
			//<tr bgcolor="{{cycle values="#FFFFFF,#F4F4F4"}}"> 
			$cor = $contador%2==0?'#FFFFFF':'#F4F4F4';
			$contador++; 
			// constru��o das linhas da tabela do filtro
			$content .= "<tr bgcolor={$cor}>\n"; 
			// Label do campo
			$content .= "<td style=\"width:25%\">\n";
			$content .= $this->view->formLabel($nome_do_campo, $atributos_do_campo['descricao']);
			$content .= "</td>\n"; 
			// verifica o tipo de dado para constru��o dos campos dentro das linhas.
			switch (strtoupper($atributos_do_campo['tipo_campo'])) {
				// case campo text
				case 'TEXT': 
					// de acordo com o tipo de dado preenche-se o array de operadores l�gicos, combo box de operadores logicos
					$content .= "<td style=\"width:25%\">\n";

					if ($atributos_do_campo['tipo_dado'] == 'string') {
						$content .= $this->view->formSelect('operadorLogico[' . $nome_do_campo . ']', $this->view->operadorLogico[$nome_do_campo], array('class' => 'medTxtArea', 'id' => 'operadorLogico[' . $nome_do_campo . ']'), $_grupoOperadoresLogico['string']);
					} else if ($atributos_do_campo['tipo_dado'] == 'numerico') {
						$content .= $this->view->formSelect('operadorLogico[' . $nome_do_campo . ']', $this->view->operadorLogico[$nome_do_campo], array('class' => 'medTxtArea', 'id' => 'operadorLogico[' . $nome_do_campo . ']'), $_grupoOperadoresLogico['numerico']);
					} 
					$content .= "</td>\n"; 
					// campo que receber� o filtro
					$content .= "<td style=\"width:30%\">";
					$content .= $this->view->formText('campo[' . $nome_do_campo . ']', $this->view->campos[$nome_do_campo], array('id' => $nome_do_campo,'style'=>'width:95%'));
					$content .= "</td>\n"; 
					// campo para verificar se o campo � Insensitive ou Sensitive Case
					if ($atributos_do_campo['tipo_dado'] != 'numerico') {
						$content .= "<td style=\"width:20%\">";
						$content .= $this->view->formCheckbox('ignoraCAb[' . $nome_do_campo . ']', $this->view->ignoraCAb[$nome_do_campo], array('class' => 'radio'),array('S','N')) . 'Ignorar CAb';
						$content .= "</td>\n";
					} else {
						$content .= "<td style=\"width:20%\">\n";
						$content .= "</td>\n";
					} 
					break; 
				// case campo radio
				case 'RADIO': 
					// de acordo com o tipo de dado preenche-se o array de operadores l�gicos, combo box de operadores logicos
					$content .= "<td style=\"width:25%\">\n";
					if ($atributos_do_campo['tipo_dado'] == 'options') {
						$content .= $this->view->formSelect('operadorLogico[' . $nome_do_campo . ']', $this->view->operadorLogico[$nome_do_campo], array('class' => 'medTxtArea', 'id' => 'operadorLogico[' . $nome_do_campo . ']'), $_grupoOperadoresLogico['options']);
					} 
					$content .= "</td>\n"; 
					// campo que receber� o filtro
					$content .= "<td colspan=2 style=\"width:50%\">\n";
					if ($atributos_do_campo['tipo_dado'] == 'options') {
						$content .= $this->view->formRadio('campo[' . $nome_do_campo . ']', $this->view->campos[$nome_do_campo], array('class' => 'radio', 'id' => $nome_do_campo), $atributos_do_campo['opcoes']);
					} 
					$content .= "</td>\n";
					break; 
				// case campo checkbox
				case 'CHECKBOX':
					break; 
				// case campo date
				case 'DATE': 
					// de acordo com o tipo de dado preenche-se o array de operadores l�gicos, combo box de operadores logicos
					$content .= "<td style=\"width:25%\">\n";
					if ($atributos_do_campo['tipo_dado'] == 'string') {
						$content .= $this->view->formSelect('operadorLogico[' . $nome_do_campo . ']', $this->view->operadorLogico[$nome_do_campo], array('class' => 'medTxtArea', 'id' => 'operadorLogico[' . $nome_do_campo . ']'), $_grupoOperadoresLogico['string']);
					} 
					$content .= "</td>\n"; 
					// campo que receber� o filtro
					$content .= "<td colspan='2' style=\"width:50%\">\n";
					$content .= $this->view->formText('campo[' . $nome_do_campo . ']', $this->view->campos[$nome_do_campo], array('class'=>'dataTxtArea', 'id'=>$nome_do_campo));
					$content .= "<img id='escolhe_{$nome_do_campo}' title='Selecione a data' src='{$this->view->baseUrl}/public/images/calendar.png' alt='Calend�rio' class='imgTb'/>";
					$content .= "<script type=\"text/javascript\">";
					$content .= "Calendar.setup({\"inputField\":\"{$nome_do_campo}\",\"button\":\"escolhe_{$nome_do_campo}\",\"singleClick\":true});";
					$content .= "</script>";
					$content .= "</td>\n";
					break; 
				// case campo select
				case 'SELECT': 
					// de acordo com o tipo de dado preenche-se o array de operadores l�gicos, combo box de operadores logicos
					$content .= "<td style=\"width:25%\">\n";
					if ($atributos_do_campo['tipo_dado'] == 'options') {
						$content .= $this->view->formSelect('operadorLogico[' . $nome_do_campo . ']', $this->view->operadorLogico[$nome_do_campo], array('class' => 'medTxtArea', 'id' => 'operadorLogico[' . $nome_do_campo . ']'), $_grupoOperadoresLogico['options']);
					} 
					$content .= "</td>\n"; 
					// campo que receber� o filtro
					$content .= "<td colspan=2 style=\"width:50%\">\n";
					if ($atributos_do_campo['tipo_dado'] == 'options') {
						if (!isset($atributos_do_campo['escolhaObrigatorio']) || $atributos_do_campo['escolhaObrigatorio'] != true) {
							$atributos_do_campo['opcoes'] = array('' => 'Selecione') + $atributos_do_campo['opcoes'];
						} 
						$content .= $this->view->formSelect('campo[' . $nome_do_campo . ']', $this->view->campos[$nome_do_campo], array('id' => $nome_do_campo, 'style'=>'width:95%'), $atributos_do_campo['opcoes']);
					} 
					$content .= "</td>\n";
					break; 
				// caso n�o seja informado um itpo para o campo assume-se que seja text
				default: 
					// de acordo com o tipo de dado preenche-se o array de operadores l�gicos, combo box de operadores logicos
					$content .= "<td style=\"width:25%\">\n";

					if ($atributos_do_campo['tipo_dado'] == 'string') {
						$content .= $this->view->formSelect('operadorLogico[' . $nome_do_campo . ']', $this->view->operadorLogico[$nome_do_campo], array('class' => 'medTxtArea', 'id' => 'operadorLogico[' . $nome_do_campo . ']'), $_grupoOperadoresLogico['string']);
					} else if ($atributos_do_campo['tipo_dado'] == 'numerico') {
						$content .= $this->view->formSelect('operadorLogico[' . $nome_do_campo . ']', $this->view->operadorLogico[$nome_do_campo], array('class' => 'medTxtArea', 'id' => 'operadorLogico[' . $nome_do_campo . ']'), $_grupoOperadoresLogico['numerico']);
					} 
					$content .= "</td>\n"; 
					// campo que receber� o filtro
					$content .= "<td style=\"width:30%\">";
					$content .= $this->view->formText('campo[' . $nome_do_campo . ']', $this->view->campos[$nome_do_campo], array('id' => $nome_do_campo));
					$content .= "</td>\n"; 
					// campo para verificar se o campo � Insensitive ou Sensitive Case
					if ($atributos_do_campo['tipo_dado'] != 'numerico') {
						$content .= "<td style=\"width:20%\">";
						$content .= $this->view->formCheckbox('ignoraCAb[' . $nome_do_campo . ']', null, array('class' => 'radio')) . 'Ignorar CAb';
						$content .= "</td>\n";
					} else {
						$content .= "<td style=\"width:20%\">\n";
						$content .= "</td>\n";
					} 
					break;
			} 
			
			// fecha a linha da tabela
			$content .= "</tr>\n";
		} 
		$content .= "</tbody>\n";
		$content .= "</table>\n"; 
		// Tabela para submeter o formul�rio
		$content .= "<table  cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"97%\">\n";
		$content .= "<tbody>\n"; 
		// inicio da linha
		$content .= "<tr>\n";
		// Label do campo
		$content .= "<td width='160px'>\n";
		$content .= "N� de registros por p�gina:\n";
		$content .= "</td>\n";

		$content .= "<td width='70px'>\n";
		$content .= $this->view->formText('numRegistrosPagina', $this->view->numRegistrosPagina, array('id' => 'numRegistrosPagina', 'class' => 'dataTxtArea'));
		$content .= "</td>\n";

		$content .= "<td>\n";
		$content .= $this->view->formSubmit('operacao', 'Pesquisar', array('id' => 'operacao', 'class' => 'btn'));
		$content .= "</td>\n"; 
		// fim da linha
		$content .= "</tr>\n";
		$content .= "</tbody>\n";
		$content .= "</table>\n";
		//$content .= "</form>";
		
		$html = $this->view->form('teste',array('method'=>'post','action'=>$this->view->baseUrl.'/'.$this->view->modulo.'/'.$this->view->controller.'/'.$this->view->action),$content);
		$this->filtro = $html;
	} 

	/**
	* Fun��o para criar a tabela de tabula��o dos dados da consulta
	* 
	* @name campoPesquisa
	* @param  array $camposPesquisa
	* <code>
	* array(
	*            nome_do_campo => array( 
	*                                   descri��o cabe�alho,
	*                                   alinhamento
	*             )
	* 
	* Tipos de alinhamento => left, center, right, monetario
	* </code>
	* @access public
	* @return void
	*/
	public function campoPesquisa($camposPesquisa,$linkRegistros){
		
		//pagina��o
		$page = $this->view->page;
		$numPaginas = $this->view->numPaginas;
		$numTotalRegistros = $this->view->numTotalRegistros;
		
		/**
		* Inicio da pagina��o
		*/
		$pagination = "\n<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"97%\">\n";
		$pagination .= "<tbody>\n"; 
		$pagination .= "<tr>\n"; 
		$pagination .= "<td height=\"24\">\n"; 
		
		//N�mero total de registros
		$pagination .= "<strong> N&deg; total de registros: </strong>".$numTotalRegistros;
		$pagination .= "</td>\n"; 
		//insere o conte�do de pagination a variavel content
		$pagination .= "<td>\n";
		$pagination .= "<div class='pagination'>";
		
		$pagination .= "<span class='pagImg'>";
		$pagination .= "<a href='{$this->view->baseUrl}/{$this->view->modulo}/{$this->view->controller}/{$this->view->action}/page/1'>";
		$pagination .= "<img border=\"0\" alt=\"Primeira p&aacute;gina\" title=\"Primeira p&aacute;gina\" src=\"{$this->view->baseUrl}/zend/public/images/pag_primeira.gif\">\n";
		$pagination .= "</a>\n"; 
		$pagination .= "</span>\n"; 
		
		$anterior = $page==1?1:$page-1;
		$pagination .= "<span class='pagImg'>";
		$pagination .= "<a href='{$this->view->baseUrl}/{$this->view->modulo}/{$this->view->controller}/{$this->view->action}/page/{$anterior}'>";
		$pagination .= "<img border=\"0\" alt=\"P&aacute;gina anterior\" title=\"P&aacute;gina anterior\" src=\"{$this->view->baseUrl}/zend/public/images/pag_anterior.gif\">\n";
		$pagination .= "</a>\n"; 
		$pagination .= "</span>\n"; 
		/**
		* meio da pagina��o
		*/
		//N�mero de p�ginas a serem exibidas
		$numeroPagina��es = 5;
		$meio = floor($numeroPagina��es/2);

		//verifica se o valor da pagina menos a metade do n�mero de pagina�oes exibidas dar� um valor  
		// inferior ao valor da primeira pagina, se positivo calcula a diferen�a que ser� acrescentado
		// ao final da �ltima p�gina a ser exibida.
		if($page-$meio<1){
			$inicio = 1;
			$restanteInicio = ($inicio-($page-$meio));
		} else {
			$inicio = $page-$meio;
			$restanteInicio = 0;
		}
		
		//verifica se o valor da pagina mais a metade do n�mero de pagina�oes exibidas dar� um valor  
		//superior ao valor da �ltima p�gina, se positivo calcula a diferen�a e subtrai do valor da primeira 
		// p�gina a ser exibida.
		if($page+$meio>$numPaginas){
			$fim = $numPaginas;
			$restanteFim = ($numPaginas-($page+$meio));
		} else {
			$fim = $page+$meio;
			$restanteFim = 0;
		}
		
		//Verifica se o n�mero de paginas de retorno da pesquisa n�o � maior que o n�mero de paginas de pesquisa pr�-definido para visualiza��o.    
		if($numPaginas > $numeroPagina��es){   
			//realiza os acr�scimos para correta exibi��o da pagina��o
			if($restanteInicio){
				$fim += $restanteInicio;
			}
			
			if ($restanteFim) {
				$inicio += $restanteFim;
			}
		} 
		

		//Constr�i os links entre o intervalo de inicio e fim das pagina��es
		$link = $inicio;
		while($link>=$inicio && $link<=$fim){
			$pagination .= "<a href='{$this->view->baseUrl}/{$this->view->modulo}/{$this->view->controller}/{$this->view->action}/page/{$link}'>";
			$pagination .= $link==$page ? "<span class=\"pagActive\">{$link}</span>" : "<span class=\"pagLink\">{$link}</span>";
			$pagination .= "</a></> ";
			$link++;
		}        
		
		/**
		* Fim da pagina��o
		*/
		$posterior = $page==$numPaginas?$numPaginas:$page+1;        
		$pagination .= "<span class='pagImg'>";
		$pagination .= "<a href='{$this->view->baseUrl}/{$this->view->modulo}/{$this->view->controller}/{$this->view->action}/page/{$posterior}'>";
		$pagination .= "<img border=\"0\" alt=\"Pr&oacute;xima p&aacute;gina\" title=\"Pr&oacute;xima p&aacute;gina\" src=\"{$this->view->baseUrl}/zend/public/images/pag_proxima.gif\">\n";
		$pagination .= "</a>\n"; 
		$pagination .= "</span>\n"; 
		$pagination .= "<span class='pagImg'>";
		$pagination .= "<a href='{$this->view->baseUrl}/{$this->view->modulo}/{$this->view->controller}/{$this->view->action}/page/{$numPaginas}'>";
		$pagination .= "<img border=\"0\" alt=\"&Uacute;ltima p&aacute;gina\" title=\"&Uacute;ltima p&aacute;gina\" src=\"{$this->view->baseUrl}/zend/public/images/pag_ultima.gif\">\n";
		$pagination .= "</a>\n"; 
		$pagination .= "</span>\n"; 
		//fecha a div pagination
		$pagination .= "</div>\n";
		$pagination .= "</td>\n"; 
		// fim da linha
		$pagination .= "</tr>\n";
		$pagination .= "</tbody>\n";
		$pagination .= "</table>\n";

		$content = $pagination;

		/**
		* �nicio da tabela de tabula��o do registros.
		*/
		$content .= "\n<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"tblPesquisa\" width=\"97%\">\n";
		$content .= "<thead>\n";
		
		//Inicia a primeira linha
		$content .= "<tr>\n";

		foreach($camposPesquisa as $cabecalho => $corpo) {
			$content .= "<th>\n";
			$content .= $cabecalho;
			$content .= "</th>\n";
			$content .= "<th width=\"8\">\n";
			$content .= "<img onclick=\"location.href='{$this->view->baseUrl}/{$this->view->modulo}/{$this->view->controller}/{$this->view->action}/order_by/{$corpo[0]} asc'\" src=\"{$this->view->baseUrl}/zend/public/images/up.png\" alt='Ordem crescente' title='Ordem crescente'>";
			$content .= "<img onclick=\"location.href='{$this->view->baseUrl}/{$this->view->modulo}/{$this->view->controller}/{$this->view->action}/order_by/{$corpo[0]} desc'\" src=\"{$this->view->baseUrl}/zend/public/images/dw.png\" alt=\"Ordem decrescente\" title=\"Ordem decrescente\">";
			$content .= "</th>\n";
		}
		$content .= "</tr>\n";
		$content .= "</thead>\n";
		
		$content .= "<tbody class=\"trLink\">\n";
		$contador = 0;              
		foreach($this->view->lista as $lista) {   
			$cor = $contador%2==0?'#FFFFFF':'#F4F4F4';
			$contador++; 
			
			/**
			* Link da tabela
			*/
			$link = $this->view->baseUrl."/".$this->view->modulo.'/'.$linkRegistros['controle'].'/'.$linkRegistros['action'];
			
			foreach($linkRegistros['params'] as $key => $value){
				$link .= "/".$value."/".$lista->$value;
			}
			
			$content .= "<tr bgcolor={$cor}  onclick=\"location.href='{$link}'\" onMouseOver=\"this.style.background = '#CCC'\" onMouseOut=\"this.style.background = '{$cor}'\">\n";
			foreach($camposPesquisa as $cabecalho => $corpo) {
				
				if(isset($corpo)){
					$id = isset($corpo[0])? $corpo[0] : "";
					$align = isset($corpo[1])? $corpo[1] == 'monetario' ? "right" : $corpo[1] : "left";
					$value = property_exists($lista,$id) ? $lista->$id : "";
					
					$content .= "<td style='text-align:{$align}' colspan='2'>\n";
					$content .= $align == 'monetario' ? $this->view->escapeFloat($value) : $this->view->escape($value);
					$content .= "</td>\n";
				}
			}
			$content .= "</tr>\n";
			
		}   
		$content .= "</tbody>\n";
		$content .= "</table>\n";
		$content .= $pagination;
		$this->tabela = $content;
	} 
} 
