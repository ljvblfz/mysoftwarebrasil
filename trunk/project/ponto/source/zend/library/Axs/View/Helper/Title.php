<?php

class Zend_View_Helper_Title{


     public function setView(Zend_View_Interface $view)
    {
         $this -> view = $view;
         }


     public function Title($mensagem)
    {
         if (empty($mensagem) || is_null($mensagem)){
             return '';
             }
        else{
             $resposta = " onmouseover=\"Tip('" . $mensagem . "')\" onmouseout=\"UnTip()\" ";
             return $resposta;
             }
         }
    }
