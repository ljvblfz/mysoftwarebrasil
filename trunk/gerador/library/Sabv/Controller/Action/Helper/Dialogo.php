<?php

require_once 'Zend/Controller/Action/Helper/Abstract.php';
require_once 'Zend/Form.php';


class Sabv_Controller_Action_Helper_Dialogo extends Zend_Controller_Action_Helper_Abstract{



     public function mostraJanelaDialogo($tipoMensagem, $mensagem, $botoes, $destino = null, $params = null)
    {

         $controller = $this -> _actionController -> getRequest() -> getControllerName();
         $action = $this -> _actionController -> getRequest() -> getActionName();
         $baseUrl = $this -> _actionController -> view -> baseUrl;

         if($this -> _actionController -> getRequest() -> getParam('confirma') == null){

             if($destino == null){
                 $destino = $baseUrl . "/" . $controller . "/" . $action;
                 }else{
                 $destino = $baseUrl . "/" . $destino;
                 }

             foreach($botoes as $nome_do_botao => $valor_do_botao){
                 $this -> _actionController -> view -> botoes .= $this -> _actionController -> view -> formSubmit('confirma', $valor_do_botao, array('class' => 'btn')) . "\n";
                 }

             if($params == null){
                 $params = $this -> _actionController -> getRequest() -> getParams();
                 }


             function constroiCampo($valor_do_campo, $nome = null, $arrayAssociativo = array()){
                 foreach($valor_do_campo as $chave => $valor){
                     if(is_array($valor)){
                         $arrayAssociativo = constroiCampo(& $valor, $nome . "[" . $chave . "]", $arrayAssociativo);
                         }else{
                         $arrayAssociativo[$nome . "[" . $chave . "]"] = $valor;
                         }

                     }
                 return $arrayAssociativo;
                 }

             foreach($params as $nome_do_campo => $valor_do_campo){
                 if(is_array($valor_do_campo)){
                     $arrayAssociativo = constroiCampo(& $valor_do_campo, $nome_do_campo);
                     foreach($arrayAssociativo as $nome => $valor){
                         if(!empty($valor)){
                             $this -> _actionController -> view -> form .= $nome . $this -> _actionController -> view -> formText($nome, $valor, array("id" => "FORM_AUX_{$nome}")) . "\n";
                             }
                         }
                     }else{
                     $this -> _actionController -> view -> form .= $nome_do_campo . $this -> _actionController -> view -> formText($nome_do_campo, $valor_do_campo, array("id" => "FORM_AUX_{$nome_do_campo}")) . "\n";
                     }
                 }

             $this -> _actionController -> view -> controller = $controller;
             $this -> _actionController -> view -> action = $action;
             $this -> _actionController -> view -> destino = $destino;
             $this -> _actionController -> view -> mensagemDialogo = $mensagem;

             switch(strtoupper($tipoMensagem)){
             case 'ALERTA':
                 $this -> _actionController -> view -> tipoMsg = 'alerta';
                 break;
             case 'INFORMACAO':
                 $this -> _actionController -> view -> tipoMsg = 'info';
                 break;
             case 'ERRO':
                 $this -> _actionController -> view -> tipoMsg = 'erro';
                 break;
             case 'CONFIRMACAO':
                 $this -> _actionController -> view -> tipoMsg = 'confirma';
                 break;
             default:
                 ;
                 }
             $this -> _actionController -> view -> dialogo = true;
             return;
             }else{
             $retorno = $this -> _actionController -> getRequest() -> getParam('confirma');
             return $retorno;
             }
         }


     public function direct($name, $options = null)
    {
         $this -> controller = $this -> getActionController();
         $this -> action = $this -> getRequest();

         return $this;
         }
    }
