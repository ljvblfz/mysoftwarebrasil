<?php


require_once 'Zend/Db/Table.php';
require_once 'Sabv/Filter/Input.php';
require_once 'Zend/Filter/StripTags.php';

class Sabv_Db_Table extends Zend_Db_Table{

     protected $_filters = null;


     protected $_validators = null;


     protected $_erros = array();


     protected $_mensagens = array();


     public function getErros(){
         return $this -> _erros;
         }


     public function getMensagens(){
         return $this -> _mensagens;
         }


     public function setErros($erros){
         foreach($erros as $campo => $arrayErros){
             foreach($arrayErros as $indiceErro => $descricaoErro){
                 $this -> _erros[$campo][] = $descricaoErro;
                 }
             }
         }


     public function setMensagens($mensagens){
         $this -> _mensagens = $this -> _mensagens + $mensagens;
         }


     public function validacaoCorreta($resultado)
    {
         $operacao_ok = false;
         if (is_array($resultado)){
             if (array_search(false, $resultado) === false && array_search(true, $resultado) !== false){
                 $operacao_ok = true;
                 }
             }
         return $operacao_ok;
         }


     protected function isValid(array & $data, $options = null)
    {
         $input = new Sabv_Filter_Input($this -> _filters, $this -> _validators, $data, $options);
         if ($input -> hasInvalid()){
             $this -> setErros($input -> getInvalid());
             return false;
             }else if ($input -> hasMissing()){
             $this -> setErros($input -> getMissing());
             return false;
             }else{
             $data = $input -> getUnescaped();
             return true;
             }
         }


     protected function array_isearch($str, $array){
         foreach ($array as $k => $v){
             if (strtolower($v) == strtolower($str)){
                 return true;
                 }
             }
         return false;
         }


     protected function converteLocaleFloat($data){

         if(!empty($this -> _validators)){

             foreach($data as $key => $value){
                 if(isset($this -> _validators[$key])){
                     $result = $this -> array_isearch('Float', $this -> _validators[$key]);

                     if($result){
                         $dataAux[$key] = str_replace('.', '', $value);
                         }else{
                         $dataAux[$key] = $value;
                         }
                     }else{
                     $dataAux[$key] = $value;
                     }
                 }
             }else{
             $dataAux = $data;
             }
         return $dataAux;
         }


     public function insertValid(array $data)
    {
         $valid = $this -> isValid($data);
         if ($valid === true){
             $data = $this -> converteLocaleFloat($data);
             return parent :: insert($data);
             }else{
             return $valid;
             }
         }


     public function updateValid(array $data, $where)
    {
         $valid = $this -> isValid($data);
         if (empty($data)){
             return 0;
             }

         if ($valid === true && !empty($where)){
             $data = $this -> converteLocaleFloat($data);
             return parent :: update($data, $where);
             }else{
             return $valid;
             }
         }



     public function getObjetoVazio()
    {
         $cols = $this -> info('cols');
         $obj = new stdClass();
         foreach($cols as $col){
             $obj -> {
                $col} = null;
             }
         return $obj;
         }


     public function getCamposUteis($parametros, $retorno = true)
    {
         if (is_array($parametros)){
             $filter = new Zend_Filter_StripTags();
             $valido = $this -> info('metadata');
             if (!$retorno){
                 $data = new stdClass();
                 foreach($parametros as $key => $value){
                     if (isset($valido[$key])){
                         $data -> $key = $filter -> filter($value);
                         }
                     }
                 $result[0] = $data;
                 return $result;
                 }
            else{
                 $data = array();
                 foreach($parametros as $key => $value){
                     if (isset($valido[$key])){
                         $data[$key] = $filter -> filter($value);
                         }
                     }
                 }
             return $data;
             }else{
             return false;
             }
         }


     public function getWhere($campos, $modo = 0)
    {
         $resposta = true;
         $chaves = $this -> info('primary');
         if ($modo != 0){
             $where = '';
             }
         if ($modo != 3){
             foreach($chaves as $key => $value){
                 if (empty($campos[$value])){
                     $resposta = false;
                     }else{
                     if ($modo == 0){
                         $where[] = "{$value} = '{$campos[$value]}'";
                         }elseif($modo == 1){
                         $where = $where . '/' . $value . '/' . $campos[$value];
                         }elseif($modo == 2){
                         $where .= $this -> getAdapter() -> quoteInto("{$value} = ?", $campos[$value]) . " AND ";
                         }
                     }
                 }
             }
        else{
             foreach($campos as $key => $value){
                 $where .= $this -> getAdapter() -> quoteInto("{$key} = ?", $value) . " AND ";
                 }
             }
         if ($modo == 2 || $modo == 3){
             $where = rtrim($where, " AND ");
             }
         return ($resposta?$where:$resposta);
         }

     public function isPrimaryKey(array $array){
         $pk = $this -> info('primary');
         if(count($array) == count($pk)){
             for($i = 1;$i <= count($pk);$i++){
                 if(isset($result[$pk[$i]])){
                     if(is_array($result[$pk[$i]])){
                         foreach($result[$pk[$i]] as $erro => $descricao){
                             return false;
                             }
                         }
                     }
                 return true;
                 }
             }else{
             return false;
             }
         }
    }
