<?php
/**
* Action Helper para auxiliar com a gera��o de janelas do tipo modal.
* 
* @name Axs_Controller_Action_Helper_Pesquisa
* @author �talo Pereira 19/6/2008 13:50:33 
* @package library
* $Id: Dialogo.php,v 1.1 2009/03/25 18:41:50 delano Exp $
*/
require_once 'Zend/Controller/Action/Helper/Abstract.php';
require_once 'Zend/Form.php';

/**
* Class Axs_Controller_Action_Helper_Pesquisa para montagem da tela de pesquisa, filtros, tabelas, pagina��o, consultas sql
* 
* @author �talo Pereira 19/6/2008 13:58:49 
* @access public 
*/
class Axs_Controller_Action_Helper_Dialogo extends Zend_Controller_Action_Helper_Abstract {


    /**
     * M�todo respons�vel por cria��o da janela modal, com funcionalidades b�sicas para cria��o de um formul�rio e postagem de dados.
     * 
     * @name confirmaOperacao 
     * @param string $tipoMensagem Tipo de mensagem
     * <code>
     * Tipos de mensagem:
     * alerta, informacao, erro, confirmacao
     * </code>
     * 
     * @param string $mensagem String contendo a imagem
     * Uma string contendo a mensagem desejada
     * 
     * @param array $botoes Bot�es da tela
     * <code>
     * array(
     *      $chave = $valor,
     * )
     * $chave => nome que � exibido na tela
     * $valor => valor que ser� retornado da confirma��o
     * </code>
     * 
     * @param string $destino Link de destino da tela
     * o par�metro destino deve ser uma string contendo o nome e o action do controle
     * ex.: controle/destino
     * 
     * @param array $params parametros que usu�rio deseja que sejam passados, caso n�o seja informado nenhum valor, s�o capturados todos os par�metros passados.
     * 
     * @access public
     * @return boolean
     */
    public function mostraJanelaDialogo($tipoMensagem,$mensagem,$botoes,$destino = null,$params = null)
    {

        //controle e action da postagem
        $modulo     = $this->_actionController->getRequest()->getModuleName();
        $controller = $this->_actionController->getRequest()->getControllerName();
        $action     = $this->_actionController->getRequest()->getActionName();
        $baseUrl    = $this->_actionController->view->baseUrl;
            
        //Se n�o tiver sido retornado a confirma��o de opera��o true, � exibida a janela modal.
        if($this->_actionController->getRequest()->getParam('confirma') == null){

            //Destino da p�gina
            if($destino == null){
                $destino = $baseUrl."/".$modulo."/".$controller."/".$action;
            } else {
                $destino = $baseUrl."/".$destino;
            }
            
            //Seta os bot�es passados por par�metro para a janela modal
            foreach($botoes as $nome_do_botao => $valor_do_botao){
                $this->_actionController->view->botoes .= $this->_actionController->view->formSubmit('confirma',$valor_do_botao,array('class'=>'btn'))."\n";
            }
                      
            //campos postados para a view
            if($params == null){
                //se usu�rio n�o tiver informado par�metros para a caixa de di�logo, 
                //s�o recuperados os campos passados pela postagem e os seta na view, 
                //para que estes dados n�o sejam perdido com o recarregamento da p�gina.
                $params = $this->_actionController->getRequest()->getParams();
            }
                        
            /**
             * Fun��o recursiva para ajuste de campos array do post do html.
             * 
             * @name constroiCampo 
             * @param array $valor_do_campo
             * @param string $nome
             * @param array $arrayAssociativo
             * @access public
             * @return array
             */
            function constroiCampo($valor_do_campo, $nome = null, $arrayAssociativo = array()){
                foreach($valor_do_campo as $chave => $valor){
                    if(is_array($valor)){
                        $arrayAssociativo = constroiCampo(&$valor,$nome."[".$chave."]",$arrayAssociativo);
                    } else {
                        $arrayAssociativo[$nome."[".$chave."]"] = $valor;
                    } 
                                               
                }
                return $arrayAssociativo;
            }  
            
            //Percorre o post e reconstr�i o formul�rio de dados
            foreach($params as $nome_do_campo => $valor_do_campo){
                if(is_array($valor_do_campo)){
                    $arrayAssociativo = constroiCampo(&$valor_do_campo,$nome_do_campo);
                    foreach($arrayAssociativo as $nome => $valor){
                        if(!empty($valor)){
                            $this->_actionController->view->form .= $nome.$this->_actionController->view->formText($nome,$valor,array("id"=>"FORM_AUX_{$nome}"))."\n";
                        }
                    }
                } else {
                    $this->_actionController->view->form .= $nome_do_campo.$this->_actionController->view->formText($nome_do_campo,$valor_do_campo,array("id"=>"FORM_AUX_{$nome_do_campo}"))."\n";
                }
            }
            
            //parametros da view
            $this->_actionController->view->controller      = $controller;
            $this->_actionController->view->action          = $action;
            $this->_actionController->view->destino         = $destino;
            $this->_actionController->view->mensagemDialogo = $mensagem; 

            //Seta o tipo de mensagem a ser exibida pela janela de Dialogo
            switch(strtoupper($tipoMensagem)){
                case 'ALERTA': 
                    $this->_actionController->view->tipoMsg = 'alerta';
                    break;
                case 'INFORMACAO': 
                    $this->_actionController->view->tipoMsg = 'info';
                    break;
                case 'ERRO': 
                    $this->_actionController->view->tipoMsg = 'erro';
                    break;
                case 'CONFIRMACAO': 
                    $this->_actionController->view->tipoMsg = 'confirma';
                    break;                    
                default:
                    ;
            }
            $this->_actionController->view->dialogo = true;
            return;
        } else {
            //retorna a op��o do usu�rio.
            $retorno = $this->_actionController->getRequest()->getParam('confirma');
            return $retorno;
        }
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
