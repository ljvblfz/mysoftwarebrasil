<?php
class Zend_View_Helper_Aba
{

     public function setView(Zend_View_Interface $view)
    {
         $this -> view = $view;
         }


     public function Aba(array $abas)
    {
         $content = "<div id=\"abas\" class=\"abas\">";
         $content .= "<div>";
         $content .= "<script>function alteraAba(chave){";
         $content .= "var abas = $('corpoAbas').childNodes;";
         $content .= "var tamanho = abas.length;";
         $content .= "for(i=0;i<tamanho;i++){";
         $content .= "abas[i].style.display = 'none';";
         $content .= "$('botao_aba_'+i).className = 'botaoAbaInativo';";
         $content .= "}";
         $content .= "$('aba_'+chave).style.display='block';";
         $content .= "$('botao_aba_'+chave).className = 'botaoAbaAtivo';";
         $content .= "} </script>";

         foreach($abas as $key => $value){
             if ($key == 0){
                 $content .= "<button id=\"botao_aba_{$key}\" type=\"button\" class=\"botaoAbaAtivo\" onclick=\"javascript:alteraAba({$key});\">{$value['title']}</button>";
                 }else{
                 $content .= "<button id=\"botao_aba_{$key}\" type=\"button\" class=\"botaoAbaInativo\" onclick=\"javascript:alteraAba({$key});\">{$value['title']}</button>";
                 }
             }

         $content .= "</div>";

         $content .= "<div id=\"corpoAbas\" class=\"corpoAbas\">";

         foreach($abas as $key => $value){
             if ($key == 0){
                 $content .= "<div id=\"aba_{$key}\" class=\"fieldLinha\">";
                 }else{
                 $content .= "<div id=\"aba_{$key}\" class=\"fieldLinha\" style=\"display:none\">";
                 }

             $content .= "{$this->view->action($value['action'], $value['controller'], null, $value['params'])}";
             $content .= "</div>";
             }

         $content .= "</div>";
         $content .= "</div>";

         return $content;
         }
    }
