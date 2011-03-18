<?php

class Zend_View_Helper_Data{


     public function setView(Zend_View_Interface $view)
    {
         $this -> view = $view;
         }


     public function Data($nome_do_campo)
    {
         $content = "";
         if(isset($nome_do_campo)){
             $content = "<img id='escolhe_{$nome_do_campo}' title='Selecione a data' src='{$this->view->baseUrl}/public/images/calendar.png' alt='Calendário' class='imgInput'/>\n";
             $content .= "<script type=\"text/javascript\">\n";
             $content .= "Calendar.setup({\"inputField\":\"{$nome_do_campo}\",\"button\":\"escolhe_{$nome_do_campo}\",\"singleClick\":true});\n";
             $content .= "</script>\n";
             }



         return $content;
         }
    }
