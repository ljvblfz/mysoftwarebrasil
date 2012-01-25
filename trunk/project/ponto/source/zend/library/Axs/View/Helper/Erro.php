<?php

class Zend_View_Helper_Erro{
     public function setView(Zend_View_Interface $view)
    {
         $this -> view = $view;
         }


     public function Erro($erros, $campos = null)
    {
         $resposta = "";
         if($campos != null){

             if (is_array($erros) && ($erros != array())){
                 $resposta = "<div id='erro'>";
                 foreach((Array)$erros as $key => $val){
                     $resposta .= "<ul>";
                     if (array_key_exists($key, $campos) && is_array($campos)){
                         $resposta .= "<li><strong>&raquo; {$campos[$key]}:</strong></li>";
                         }else{
                         $resposta .= "<li>{$key}";
                         }
                     foreach((Array)$val as $val1){
                         $resposta .= "<ul><li>::  " . $val1 . "</li></ul>";
                         }
                     $resposta .= "</li></ul>";
                     }
                 $resposta .= "</div>";
                 }
             }else{
             if (is_array($erros) && ($erros != array())){
                 foreach((Array)$erros as $key => $val){
                     $resposta .= "var arrayItem = new Array();";
                     $resposta .= "arrayItem[0] = document.getElementsByTagName('input');";
                     $resposta .= "arrayItem[1] = document.getElementsByTagName('select');";
                     $resposta .= "arrayItem[2] = document.getElementsByTagName('textarea'); ";

                     $resposta .= "for(i=0;i<arrayItem.length;i++){";
                     $resposta .= "    for(j=0;j<arrayItem[i].length;j++){";
                     $resposta .= "        var nomecampo = arrayItem[i][j];";
                     $resposta .= "        var tem = nomecampo.name.indexOf('{$key}');";
                     $resposta .= "        if(tem != -1){";
                     $resposta .= "            nomecampo.style.border = '2px solid #FF1200';";
                     $resposta .= "        }";
                     $resposta .= "    }";
                     $resposta .= "}";
                     }
                 }
             }


         return $resposta;
         }
    }
