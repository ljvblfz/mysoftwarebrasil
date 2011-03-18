<?php

class Zend_View_Helper_Mensagem{


     public function setView(Zend_View_Interface $view)
    {
         $this -> view = $view;
         }


     public function Mensagem($mensagens)
    {
         $resposta = "";
         if (is_array($mensagens) && $mensagens != array()){
             $resposta = "<div id='message'>";
             foreach($mensagens as $key => $val){
                 $resposta .= "<ul>";
                 $resposta .= "<li>&raquo; " . $val . "</li>";
                 $resposta .= "</ul>";
                 }
             $resposta .= "</div>";
             }
         return $resposta;
         }
    }
