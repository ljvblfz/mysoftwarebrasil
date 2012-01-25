<?php

class Zend_View_Helper_escapeFuncional{


     public function setView(Zend_View_Interface $view)
    {
         $this -> view = $view;
         }


     public function escapeFuncional($valor)
    {
         $ns = Zend_Registry :: get('ns');

         if(is_null($ns -> mascaraFuncional)){
             $ano = Zend_Auth :: getInstance() -> getIdentity() -> US_ANO;
             $entidade = Zend_Auth :: getInstance() -> getIdentity() -> US_ENTIDADE;

             Zend_Loader :: loadClass('Funcional');
             $funcional = new Funcional();

             $select = $funcional -> select()
             -> from($funcional)
             -> where("FU_ANO = '{$ano}' AND FU_ENTIDADE = '{$entidade}'");
             $arrayFuncional = $funcional -> fetchAll($select) -> toArray();
             $ns -> mascaraFuncional = $arrayFuncional;
             }else{
             $arrayFuncional = $ns -> mascaraFuncional;
             }

         $result = '';
         if(!empty($valor)){
             $valor = str_replace('.', '', $valor);

             for($i = 0;$i < count($arrayFuncional);$i++){
                 $result .= substr($valor, $arrayFuncional[$i]['FU_POS']-1, $arrayFuncional[$i]['FU_TAM']);
                 if($i + 1 != count($arrayFuncional)){
                     $result .= '.';
                     }
                 }
             }

         return $result;
         }
    }
