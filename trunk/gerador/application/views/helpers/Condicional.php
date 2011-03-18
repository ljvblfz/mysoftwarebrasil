<?php

class Zend_View_Helper_condicional{


     public function setView(Zend_View_Interface $view)
    {
         $this -> view = $view;
         }


     public function condicional($arrayAtributosHtml, $arrayCondicionalAtributosHtml, $condicional)
    {
         if(is_null($arrayAtributosHtml)){
             $arrayAtributosHtml = array();
             }
         if($condicional == true){
             return array_merge($arrayAtributosHtml, $arrayCondicionalAtributosHtml);
             }elseif($condicional == false){
             return $arrayAtributosHtml;
             }
         }
    }
