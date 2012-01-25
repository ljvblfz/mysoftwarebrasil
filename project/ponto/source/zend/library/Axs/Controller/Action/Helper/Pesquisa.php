<?php
/**
 * Action Helper para auxiliar na constru��o da tela de pesquisa, utiliza o view helper
 * pequisa Zend_View_Helper_Pesquisa para poder construir as interfaces automaticamente 
 * com as informa�oes passadas.
 * 
 * @name Axs_Controller_Action_Helper_Pesquisa
 * @author 
 * @package 
 * @version 
 */
require_once 'Zend/Controller/Action/Helper/Abstract.php';

/**
* Class Axs_Controller_Action_Helper_Pesquisa para montagem da tela de pesquisa, filtros, tabelas, pagina��o, consultas sql
* 
* @author �talo Pereira 19/6/2008 13:58:49 
* @access public 
*/
class Axs_Controller_Action_Helper_Pesquisa extends Zend_Controller_Action_Helper_Abstract {
    /**
    * Modelos que far�o parte da pesquisa.
    * 
    * @name $modelos
    * @access protected
    * @var array
    */
    protected $modelos;
    
    /**
    * Filtros da pesquisa, filtros a serem utilizados pelo usu�rio para refino da consulta.
    * 
    * @name $filtros
    * @access protected
    * @var array
    */
    protected $filtros;

    /**
    * Campos que constituir�o a tabela de resultado da consulta.
    * 
    * @name $campos
    * @access protected
    * @var array
    */
    protected $campos;

    /**
    * Vari�vel que armazenar� a forma de constru��o do link de cada registro de resultado da pesquisa.
    *   
    * @name $linkRegistros
    * @access protected
    * @var array
    */
    protected $linkRegistros;
    
    /**
     * Filtros padr�o da consulta, por exemplo ano, entidade.
     * 
     * @name $filtroPadrao 
     * @access protected
     * @var array
     */
    protected $filtroPadrao;
    
    /**
     * Ordena��o padr�o, esta ordena��o ordenar� o resultado da consulta inicialmente.
     * 
     * @name $orderPadrao 
     * @access protected
     * @var array
     */
    protected $orderPadrao;

    /**
     * Group By da consulta, n�o obrigat�rio.
     * 
     * @name $groupBy 
     * @access protected
     * @var string
     */
    protected $groupBy;
    
    /**
     * Clausula having, funciona somente com o group by.
     * 
     * @name $orderPadrao 
     * @access $having
     * @var string
     */
    protected $having;        
    
    /**
    * M�todo por constru��o por pesquisa.
    * 
    * @name montaPesquisa
    * @param array $modelos modelos que far�o parte de nossa pesquisa.
    * <code>
    * configura��o do array modelos:
    * array(from => nome_tabela,
    *           join => array(
    *                         nome_tabela' => array(
    *                                               relacionamento => relacionamento,
    *                                               tipo           => tipo_join
    *                                              ),
    *                          );
    * 
    * nome da tabela pode ser string ou ent�o um array, se for array dever� ter a seguinte configura��o:
    * array(nome_tabela => array(campo1, campo2, etc));
    * 
    * valores para tipo_join:
    *                   join        - tipo de relacionamento innerjoin, 
    *                   left        - tipo de relacionamento leftjoin, 
    *                   right       - tipo de relacionamento rightjoin, 
    *                   full        - tipo de relacionamento fulljoin, 
    *                   cross       - tipo de relacionamento crossjoin, 
    *                   natural     - tipo de relacionamento naturaljoin
    * </code>
    * @param array $filtroPesquisa compor� a parte de filtros da pesquisa
    * <code>
    * configura��o do array $filtroPesquisa:
    * array(
    *                nome_do_campo => array( 
    *                                       tipo_campo         => tipo_do_campo //string
    *                                       tipo_dado          => tipo_do_dado  //string
    *                                       descricao          => descricao_do_campo // string
    *                                       escolhaObrigatorio => escolhaObrigatorio // default(false) mostra a primeira op��o do select vazio ou n�o.
    *                                       opcoes             => array( //op��es para preechimento de campos radio, select
    *                                                                   chave => valor// array associativo
    *                                                                  )
    *                                       ) 
    *           )
    * Tipos para:
    * tipo_campo  - respons�vel por montar o tipo de campo html a ser utilizado
    *                   select      - campos combobox
    *                   text        - campos texto comuns 
    *                   radio       - campos radio 
    *                   checkbox    - campos checkbox
    *                   date        - campos texto para data, com op��o de bot�o de calend�rio
    * tipo_dado   - respons�vel por carregar o combo box com os operadores de igualdade, ex; igual, maior, menor, etc. 
    *                   numerico    - carrega os operadores compat�veis com campos de valores n�mericos.   
    *                   string      - carrega os operadores compat�veis com campos de valores string.
    *                   options     - carrega os operadores compat�veis com campos de valores options.
    * escolhaObrigatorio - torna ou n�o um campo select obrigatorio, se n�o obrigatorio aparece uma op��o selecione, se obrigat�rio n�o existe esta op��o
    *                 - true        - torna obrigat�rio
    *                 - false       - n�o obrigat�rio (default)
    * 
    * </code>
    * @param array $camposPesquisa campos respons�veis pela constru��o da tabela e tabula��o dos dados.
    * <code>
    * configura��o do array $camposPesquisa:
    * array(
    *                nome_do_campo => array( 
    *                                       descri��o cabe�alho,
    *                                       alinhamento 
    *                 )
    * 
    * Tipos de alinhamento para valores em tabelas 
    *                   left    - alinhamento a esquerda. 
    *                   center  - alinhamento ao centro.
    *                   right   - alinhamento a direita.
    * </code>
    * @param array $linkRegistros 
    * <code>
    * configura��o do array $linkRegistros:
    * array(
    *           'controle'      =>'nome_do_controle',
    *           'action'        =>'nome_do_action',
    *           'params'        =>array(
    *                                   'tipo_parametro' => 'values'
    *                                   ),
    * );
    * 
    * Op��es para tipo_parametro => values:
    *                           chave       => values - o link ser� constru�do com os campos da chave do modelo informado pelo usu�rio.
    *                           todos       => values - o link ser� constru�do com todos os campos do retorno da consulta 
    *                           informado   => values - o link ser� constru�do com os campos informados pelo usu�rios, os campos ser�o informados em uma string e separdos por ()
    *                           cabecalho   => values - o link ser� constru�do com os campos que comp�em o cabe�alho da tabela 
    * </code>
    * @param array filtroPadrao
    * <code>
    * configura��o do array filtroPadrao:
    * array de condi�oes do fitro padr�o
    * ex.: 
    * array('UG_ANO = 2222','UG_CODIGO in (2222,0122,0133)'),
    * </code>
    * @param boolean $mostraFiltro
    * <code>
    * true -> para carregar a tela exibindo o filtro
    * false -> para carregar a tela escondendo o filtro
    * </code>
    * @param array orderPadrao
    * <code>
    * configura��o do array orderPadrao:
    * array(
    *       nome_do_campo => asc|desc
    *      )
    * </code>
    * @param array groupBy
    * ex.: array("nome_do_campo1", "nome_do_campo2", "nome_do_campo3", "... etc");
    * @param string having
    * ex.: "nome_do_campo1 > 0, nome_do_campo2 = 2, nome_do_campo3 in (0,1,2), ... etc";
    * @access public 
    * @return void 
    */
    public function Pesquisa($modelos, $filtros, $campos, $linkRegistros, $filtroPadrao = null, $mostraFiltro = false, $orderPadrao = array(), $groupBy = null, $having = null)
    {
        $this->modelos          = $modelos;//modelos 
        $this->filtros          = $filtros;//filtros
        $this->campos           = $campos; //campos 
        $this->linkRegistros    = $linkRegistros; //linkRegistros 
        $this->filtroPadrao     = $filtroPadrao;//filtroPadrao
        $this->orderPadrao      = $orderPadrao;//orderPadrao
        $this->groupBy          = $groupBy;//group by
        $this->having           = $having;//having
        
        // recupera o nome do controller e seta na variavel controller passada para a view
        $this->_actionController->view->controller = $this->getActionController()->getRequest()->getModuleName().'/'.$this->_actionController->getRequest()->getControllerName(); 
        // recupera o nome do action e seta na variavel action passada para a view
        $this->_actionController->view->action = $this->_actionController->getRequest()->getActionName();
        // recupera o nome do action e seta na variavel action passada para a view
        if($mostraFiltro == false){
            $this->_actionController->view->mostraFiltro = 'none';
        } else {
            $this->_actionController->view->mostraFiltro = 'block';
        }
        // solicita o metodo a consulta
        $this->realizaConsulta(); 
        // ajusta o link do registro de acordo com os par�metros informados pelo usu�rio.
        $link = $this->ajustaLinkRegistro(); 
        // solicita a constru��o da tela j� utilizando o retorno da consulta
        $this->_actionController->view->Pesquisa($this->filtros, $this->campos, $link);
    } 

    /**
    * M�todo respons�vel por construir a consulta no banco de dados, os filtros s�o passados via POST e recuperados com auxilio.
    * 
    * @name realizaConsulta
    * @param array $modelos modelos que far�o parte de nossa pesquisa.
    * <code>
    * array(from => nome_tabela,
    *           join => array(
    *                         nome_tabela' => array(
    *                                               relacionamento => relacionamento,
    *                                               tipo           => tipo_join
    *                                              ),
    *                          );
    * 
    * valores para tipo_join:
    *                   join        - tipo de relacionamento innerjoin, 
    *                   left        - tipo de relacionamento leftjoin, 
    *                   right       - tipo de relacionamento rightjoin, 
    *                   full        - tipo de relacionamento fulljoin, 
    *                   cross       - tipo de relacionamento crossjoin, 
    *                   natural     - tipo de relacionamento naturaljoin
    * </code>
    * @access public 
    * @return void 
    */
    protected function realizaConsulta()
    {
        // modelos
        $modelos = $this->modelos;
        // tipos de join para query
        $tipoJoin = array('join' => 'join',
            'left'      => 'joinLeft',
            'right'     => 'joinRight',
            'full'      => 'joinFull',
            'cross'     => 'joinCross',
            'natural'   => 'joinNatural'
            ); 
        // Captura a inst�ncia de db dentro de Zend_Registry
        $db = Zend_Registry::get('db');
        $select = $db->select(); 
                // Select na tabela de consulta, verifica se � array ou string
        if(is_string($modelos['from'])){
            $select->from($modelos['from'], '*');
        } else if(is_array($modelos['from'])) {
            list($tabela, $campos) =  each($modelos['from']);
            $select->from($tabela, $campos);
        }
        // join entre as tabelas
        if(isset($modelos['join'])){
            foreach($modelos['join'] as $tabela => $atributos) {
                if(!isset($atributos['campo'])){
                    $select->$tipoJoin[$atributos['tipo']]($tabela, $atributos['relacionamento'], '*');
                } else {
                    $select->$tipoJoin[$atributos['tipo']]($tabela, $atributos['relacionamento'], $atributos['campo']);
                }
                
            } 
        }
		if (isset($modelos['distinct']) && $modelos['distinct']) {
        	$select->distinct();
        }        
        // cria sessao para guardar dados do safci e coloca timeou em 60 segundos
        $ns = Zend_Registry::get('ns'); 
        //nome do controle utilizando a class
        $controller = $this->_actionController->getRequest()->getControllerName();
        // n�mero de registros por p�gina
        $numRegistrosPagina = is_null($this->_actionController->getRequest()->getParam('numRegistrosPagina')) ? 20 : $this->_actionController->getRequest()->getParam('numRegistrosPagina'); 
        
        //captura o n�mero da p�gina;
        $page = $this->_actionController->getRequest()->getParam('page');

        //Captura o order
        $orderBy = $this->_actionController->getRequest()->getParam('order_by');

        /**
        * Realiza a manipula��o do filtro informado para que os dados do usu�rio n�o sejam perdido durante 
        * o reload.
        * Controla os valores dos filtros de pesquisa, as pagina��es e ordena��es, dos resultados
        */
        if (!$page && empty($orderBy)) {
            $ns->pesquisa[$controller]['campos']             = $campos           = $this->_actionController->getRequest()->getParam('campo');
            $ns->pesquisa[$controller]['operadorLogico']     = $operadorLogico   = $this->_actionController->getRequest()->getParam('operadorLogico');
            $ns->pesquisa[$controller]['operadorBooleano']   = $operadorBooleano = $this->_actionController->getRequest()->getParam('operadorBooleano');
            $ns->pesquisa[$controller]['ignoraCAb']          = $ignoraCAb        = $this->_actionController->getRequest()->getParam('ignoraCAb');
            $ns->pesquisa[$controller]['numRegistrosPagina'] = $numRegistrosPagina;
            $page = 1;
        } else {
            $campos             = $ns->pesquisa[$controller]['campos'];
            $operadorLogico     = $ns->pesquisa[$controller]['operadorLogico'];
            $operadorBooleano   = $ns->pesquisa[$controller]['operadorBooleano'];
            $ignoraCAb          = $ns->pesquisa[$controller]['ignoraCAb'];
            $numRegistrosPagina = empty($ns->pesquisa[$controller]['numRegistrosPagina'])?$numRegistrosPagina:$ns->pesquisa[$controller]['numRegistrosPagina'];
            $page = empty($page)?1:$page;
        }
        //utiliza o order passado
        if($orderBy){
            $ns->pesquisa[$controller]['order'] = $orderBy;
        }else if(isset($ns->pesquisa[$controller]['order'])){
            $orderBy = $ns->pesquisa[$controller]['order'];
        } 
        if($orderBy == null){
            $orderBy = $this->orderPadrao;
        } else {
            $orderBy = array($orderBy);
        }
        $select->order($orderBy);
        
        //group by e having
        if(!is_null($this->groupBy)){
            $select->group($this->groupBy);
            if(!is_null($this->having)){
                $select->having($this->having);
            }            
        }

        // se existirem campos passados por post.
        if (!empty($campos)) {

            foreach($campos as $nome_campo => $value_campo) {
                if (!empty($value_campo) || $value_campo == '0' || $value_campo === 0) {
                    $nome_campo_aux = $nome_campo;
                    
                    // Seleciona o operador l�gico
                    $operadorBooleano[$nome_campo] = !empty($operadorBooleano[$nome_campo])?$operadorBooleano[$nome_campo]:'where';
                    switch ($operadorLogico[$nome_campo_aux]) {
                        case 'OPL_IGUAL':
                            if (isset($ignoraCAb[$nome_campo]) && $ignoraCAb[$nome_campo] == 'S') {
                                $select->where("upper({$nome_campo}) = upper('{$value_campo}')");
                            } else {
                                $select->where("{$nome_campo} = '{$value_campo}'");
                            }
                            break;
                        case 'OPL_DIFERENTE':
                            if (isset($ignoraCAb[$nome_campo]) && $ignoraCAb[$nome_campo] == 'S') {
                                $select->where("upper({$nome_campo}) != upper('{$value_campo}')");
                            } else {
                                $select->where("{$nome_campo} != '{$value_campo}'");
                            }
                            break;
                        case 'OPL_MAIOR':
                            $select->where("{$nome_campo} > '{$value_campo}'");
                            break;
                        case 'OPL_MENOR':
                            $select->where("{$nome_campo} < '{$value_campo}'");
                            break;
                        case 'OPL_MAIOR_IGUAL':
                            $select->where("{$nome_campo} >= '{$value_campo}'");
                            break;
                        case 'OPL_MENOR_IGUAL':
                            $select->where("{$nome_campo} <= '{$value_campo}'");
                            break;
                        case 'OPL_ENTRE':
                            $value_campo = split("[ ;-]", $value_campo);
                            $select->where("{$nome_campo} >= {$value_campo[0]} AND {$nome_campo} <= {$value_campo[1]}");
                            break;
                        case 'OPL_VAZIO':
                            $select->where("{$nome_campo} is null");
                            break;
                        case 'OPL_NAO_VAZIO':
                            $select->where("{$nome_campo} is not null");
                            break;
                        case 'OPL_VALOR_LISTA':
                            $select->where("{$nome_campo} in ({$value_campo})");
                            break;
                        case 'OPL_COMECANDO':
                            if (isset($ignoraCAb[$nome_campo]) && $ignoraCAb[$nome_campo] == 'S') {
                                $select->where("upper({$nome_campo}) like upper('{$value_campo}%')");
                            } else {
                                $select->where("{$nome_campo} like '{$value_campo}%'");
                            }
                            break;
                        case 'OPL_TERMINANDO':
                            if (isset($ignoraCAb[$nome_campo]) && $ignoraCAb[$nome_campo] == 'S') {
                                $select->where("upper({$nome_campo}) like upper('%{$value_campo}')");
                            } else {
                                $select->where("{$nome_campo} like '%{$value_campo}'");
                            }
                            break;
                        case 'OPL_QUALQUER_LUGAR':
                            if (isset($ignoraCAb[$nome_campo]) && $ignoraCAb[$nome_campo] == 'S') {
                                $select->where("upper({$nome_campo}) like upper('%{$value_campo}%')");
                            } else {
                                $select->where("{$nome_campo} like '%{$value_campo}%'");
                            }
                            break;
                        default: ;
                    } // switch
                }
            } 
            // Retorna os filtros para a view.
            $arrayCampos = array('campos' => $campos);
            $this->_actionController->view->assign($arrayCampos);

            $arrayOperadorLogico = array('operadorLogico' => $operadorLogico);
            $this->_actionController->view->assign($arrayOperadorLogico);

            $arrayOperadorBooleano = array('operadorBooleano' => $operadorBooleano);
            $this->_actionController->view->assign($arrayOperadorBooleano);

            $arrayIgnoraCAb = array('ignoraCAb' => $ignoraCAb);
            $this->_actionController->view->assign($arrayIgnoraCAb);
        } 
        if(!empty($this->filtroPadrao)){
            foreach($this->filtroPadrao as $key => $value){
                $select->where($value);
            }
        }
        
        
        
        // Seta a numRegistrosPagina na view
        $this->_actionController->view->numRegistrosPagina = $numRegistrosPagina;

        // recuperando o n�mero de p�ginas do registro a ser executado
        $sql = "SELECT COUNT(*) as total from (" . $select->__toString() . ") tab";
        try {
            //die($select->__toString());
            $numTotalRegistros = $db->fetchRow($sql); 
        } 
        catch (Exception $e) {
            // can't log it - display error message
            die($select->__toString()); 
            break;
            //die("<p>An error occurred with logging an error!");
        }
        
        
        // N�mero de p�ginas
        $numPaginas = $numTotalRegistros->total / $numRegistrosPagina;
        $numPaginas = ceil(($numPaginas < 1)?1:$numPaginas); 
        // Seta na view o n�mero da p�gina, o n�mero de p�ginas, e o total de registros da pesquisa.
        $this->_actionController->view->page = $page;
        $this->_actionController->view->numPaginas = $numPaginas;
        $this->_actionController->view->numTotalRegistros = $numTotalRegistros->total; 
        // Define a p�gina e o n�mero de registros por p�gina
        $select->limitPage($page, $numRegistrosPagina); 
        // Realiza a consulta na P�gina passada pelo usu�rio
        $objeto = $db->fetchAll($select); 
        // $nap = new Nap();
        $this->_actionController->view->lista = $objeto;
    } 

    /**
    * Ajusta o link para os registros de acordo com o tipo de parametro informado pelo usu�rio.
    * 
    * @name ajustaLinkRegistro
    * @param array $linkRegistros 
    * @access public 
    * @return 
    */
    protected function ajustaLinkRegistro()
    {
        $linkRegistros = $this->linkRegistros;

        // Seleciona o tipo de link desejado pelo usu�rio
        list($key, $value) = each($linkRegistros['params']);
        switch ($key) {
            case 'chave':
                
                $value = ucfirst($value);
                Zend_Loader::loadClass($value);
                $model = new $value;
                $params = $model->info('primary');
                break;
            case 'todos':
                
                break;
            case 'informado':
                $params = split('[|.,-]', $value);
                break;
            default:
                Zend_Loader::loadClass($value);
                $model = new $value;
                $params = $model->info('primary');
        } // switch$linkRegistros
        $linkRegistros['params'] = $params;
        return $linkRegistros;
    } 

    /**
    * M�todo autom�tico do action helper
    * 
    * @name direct
    * @param  $name 
    * @param  $options 
    * @access public 
    * @return object actionHelper
    */
    public function direct($name, $options = null)
    {
        $this->controller = $this->getActionController();
        $this->action = $this->getRequest();

        return $this;
    } 
} 
