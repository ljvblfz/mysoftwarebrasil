<?php


require_once 'Sabv/Relatorio/Util/ValidateUrl.php';
require_once 'Sabv/Relatorio/Util/MyCurl.php';


define("ERRO_PHP", 0);


define("ERRO_SERVLET", 1);


define("SERVLET_DB", "/dburl");


class Sabv_Relatorio_Request{

     private $ocorreu_erro = false;


     private $tipo_erro = '';


     private $msg_erro = 'Não ocorreu nenhum erro!';


     private $pontes_validas = '';


     private $tipos_validos = '';


     private $servlet_url = '';


     private $servlet_bd_url = '';


     private $ponte = '';


     private $tipo = '';


     private $nome_arquivo = '';


     private $sql = '';


     private $cod_rel = '';


     private $param = array();


     private $down = 0;


     public $html_page_break = true;


     function __construct()
    {
         $this -> pontes_validas = array("post", "get");
         $this -> tipos_validos = array("pdf", "html", "csv", "xls", "xml");
         }


     private function setMensagemErro($msg, $tipo = ERRO_PHP)
    {
         if (is_string($msg) && is_int($tipo)){
             $this -> msg_erro = $msg;
             $this -> tipo_erro = $tipo;
             return true;
             }
        else
             return false;
         }


     public function getMensagemErro()
    {
         return $this -> msg_erro;
         }


     public function getTipoErro()
    {
         return $this -> tipo_erro;
         }


     public function setPonte($ponte)
    {
         if (in_array($ponte, $this -> pontes_validas)){
             $this -> ponte = $ponte;
             return true;
             }else{
             if (!$this -> ocorreu_erro){
                 $this -> setMensagemErro("Ponte invalida");
                 $this -> ocorreu_erro = true;
                 }
             return false;
             }
         }


     public function setServletUrl($url)
    {
         if (Sabv_Relatorio_Util_ValidateUrl :: validateUrlSyntax($url, 'p?')){
             $this -> servlet_url = $url;
             $this -> servlet_bd_url = $this -> getServletBDUrl($url);
             return true;
             }
        else{
             if (!$this -> ocorreu_erro){
                 $this -> setMensagemErro("Url invalida");
                 $this -> ocorreu_erro = true;
                 }
             return false;
             }
         }


     private function getServletBDUrl($url_servlet_bd)
    {
         $parte1 = explode("//", $url_servlet_bd);
         $parte2 = explode("/", $parte1[1]);

         $num = count($parte2)-1;
         $str_tmp = "";
         for ($i = 0; $i < $num; $i++){
             if ($str_tmp == ""){
                 $str_tmp = $parte2[$i];
                 }
            else{
                 $str_tmp = $str_tmp . "/" . $parte2[$i];
                 }
             }
         $servlet_db = "http://" . $str_tmp . SERVLET_DB;

         return $servlet_db;
         }


     public function getServletUrl()
    {
         if (strcmp($this -> servlet_url, '') != 0)
             return $this -> servlet_url;
         else{
             if (defined('SERVLET_RELATORIO')){
                 $this -> setServletUrl(SERVLET_RELATORIO);
                 return $this -> servlet_url;
                 }
            else if (!$this -> ocorreu_erro){
                 $this -> setMensagemErro("Url do servlet nao inicializada");
                 $this -> ocorreu_erro = true;
                 }
             return false;
             }
         }


     public function getPonte()
    {
         if (strcmp($this -> ponte, '') != 0)
             return $this -> ponte;
         else{
             if (!$this -> ocorreu_erro){
                 $this -> setMensagemErro("Ponte nao inicializada");
                 $this -> ocorreu_erro = true;
                 }
             return false;
             }
         }


     public function setTipo($tipo, $page_break = true)
    {
         if (in_array($tipo, $this -> tipos_validos) && (is_bool($page_break))){
             $this -> tipo = $tipo;
             if ($page_break){
                 $this -> html_page_break = "true";
                 }
            else{
                 $this -> html_page_break = "false";
                 }
             return true;
             }else{
             if (!$this -> ocorreu_erro){
                 if (!in_array($tipo, $this -> tipos_validos)){
                     $this -> setMensagemErro("Tipo invalido");
                     }
                else{
                     $this -> setMensagemErro("O parâmetro html_page_break deve ser um booleano");
                     }
                 $this -> ocorreu_erro = true;
                 }
             return false;
             }
         }


     public function getTipo()
    {
         if (strcmp($this -> tipo, '') != 0)
             return $this -> tipo;
         else{
             if (!$this -> ocorreu_erro){
                 $this -> setMensagemErro("Tipo nao inicializado");
                 $this -> ocorreu_erro = true;
                 }
             return false;
             }
         }


     public function setNomeArquivo($nome)
    {
         if (is_string($nome)){
             $this -> nome_arquivo = $nome;
             return true;
             }else{
             if (!$this -> ocorreu_erro){
                 $this -> setMensagemErro("Nome de arquivo jasper invalido");
                 $this -> ocorreu_erro = true;
                 }
             return false;
             }
         }


     public function getNomeArquivo()
    {
         if (strcmp($this -> nome_arquivo, '') != 0)
             return $this -> nome_arquivo;
         else{
             if (!$this -> ocorreu_erro){
                 $this -> setMensagemErro("Nome de arquivo jasper nao inicializado");
                 $this -> ocorreu_erro = true;
                 }
             return false;
             }
         }


     public function setSql($query)
    {
         if (is_string($query)){
             $this -> sql = $query;
             return true;
             }else{
             if (!$this -> ocorreu_erro){
                 $this -> setMensagemErro("Query invalida");
                 $this -> ocorreu_erro = true;
                 }
             return false;
             }
         }


     public function getSql()
    {
         if (strcmp($this -> sql, '') != 0)
             return $this -> sql;
         else{
             if (!$this -> ocorreu_erro){
                 $this -> setMensagemErro("Query nao inicializada");
                 $this -> ocorreu_erro = true;
                 }
             return false;
             }
         }


     public function setCodRel($cod_rel)
    {
         if (is_int($cod_rel)){
             $this -> cod_rel = $cod_rel;
             return true;
             }else{
             if (!$this -> ocorreu_erro){
                 $this -> setMensagemErro("Codigo de relatorio invalido");
                 $this -> ocorreu_erro = true;
                 }
             return false;
             }
         }


     public function setDown($tmp)
    {
         if (($tmp == 0) || ($tmp == 1)){
             $this -> down = $tmp;
             return true;
             }else{
             if (!$this -> ocorreu_erro){
                 $this -> setMensagemErro("Parametro de download invalido");
                 $this -> ocorreu_erro = true;
                 }
             return false;
             }
         }


     public function getDown()
    {
         if (($this -> down == 0) || ($this -> down == 1)){
             return $this -> down;
             }else{
             if (!$this -> ocorreu_erro){
                 $this -> setMensagemErro("Parametro de download invalido");
                 $this -> ocorreu_erro = true;
                 }
             return false;
             }
         }


     public function setParam($nome, $valor)
    {
         $tmp = urlencode($valor);
         if (Sabv_Relatorio_Util_ValidateUrl :: validateUrlSyntax("www.teste.com?" . "$nome" . "=" . "$tmp", '')){
             $this -> param[$nome] = $valor;
             return true;
             }else{
             if (!$this -> ocorreu_erro){
                 $this -> setMensagemErro("Parametro invalido");
                 $this -> ocorreu_erro = true;
                 }
             return false;
             }
         }


     public function getParam()
    {
         if ((count($this -> param) > 0)){
             return $this -> param;
             }else{
             if (!$this -> ocorreu_erro){
                 $this -> setMensagemErro("Parametro(s) nao inicializado(s)");
                 $this -> ocorreu_erro = true;
                 }
             return false;
             }
         }


     private function formataParametros($separador = ",")
    {
         $tmp = '';
         reset($this -> param);
         while (list($key, $value) = each($this -> param)){
             if (strcmp($separador, "&") == 0){
                 $value = urlencode($value);
                 $tmp = "$tmp" . "$key" . "=" . "$value" . "$separador";
                 }
            else
                 $tmp = "$tmp" . "$key" . "=" . "$value" . "$separador";
             }
         $tmp = substr($tmp, 0, strlen($tmp)-1);
         return $tmp;
         }


     private function verificaParametrosObrigatorios()
    {
         if (strcmp($this -> ponte, "post") == 0){
             if ($this -> getServletUrl() == false){
                 return false;
                 }else if ($this -> getNomeArquivo() == false){
                 return false;
                 }else if ($this -> getTipo() == false){
                 return false;
                 }else if ($this -> getParam() == false){
                 return false;
                 }else{
                 return true;
                 }
             }
         if (strcmp($this -> ponte, "get") == 0){
             if ($this -> getServletUrl() == false){
                 return false;
                 }else if ($this -> getNomeArquivo() == false){
                 return false;
                 }else if ($this -> getTipo() == false){
                 return false;
                 }else if ($this -> getParam() == false){
                 return false;
                 }else{
                 return true;
                 }
             }
         return false; //se nao existir nenhuma ponte
         }


     private function trataDadosServletBD($md5)
    {
         $md5_banco = explode(":", $md5);

         if ($md5_banco[0] != 'OK'){
             $resposta = "Não foi possível obter as informações sobre o Banco de Dados utilizado pelo Servlet.\n A conexão com o banco de dados pode não ser bem sucedida.";
             }
        else{

             $urlConexao = $dadosConexao['hostspec'] . (($dadosConexao['port'] == false)?'':':' . $dadosConexao['port']) . '/' . $dadosConexao['database'];
             $md5_php = array(md5($dadosConexao['username']), md5($urlConexao));

             if (strcmp(trim($md5_banco[1]), trim($md5_php[0])) != 0){
                 $resposta = "O usuário do banco de dados do Servlet é diferente do usuário atual.\n Os dados podem não ser obtidos corretamente.";
                 }
            elseif (strcmp(trim($md5_banco[2]), trim($md5_php[1])) != 0){
                 $resposta = "A URL de acesso ao Banco de Dados do Servlet é diferente da URL atual.\n Os dados retornados podem ser diferente do esperado.";
                 }
            else{
                 $resposta = false; // as informações estão coerentes
                 }
             }
         return $resposta;
         }


     public function confirmaRel(){

         return true;
         }


     public function mostraRel($mostraDialogo = true)
    {
         if ($mostraDialogo){
             $this -> confirmaRel();
             }

         switch ($this -> ponte){
         case 'post':
             if ($this -> verificaParametrosObrigatorios()){
                 $param = $this -> formataParametros("&");

                 $fixos = "ponte=post" . "&tipo=" . "$this->tipo" . "&nome_arquivo=";
                 $fixos = "$fixos" . "$this->nome_arquivo" . "&down=" . "$this->down" . "&$param";

                 if ($this -> getTipo() == "html"){
                     $fixos = $fixos . "&html_page_break=" . "{$this->html_page_break}";
                     }

                 $opc = '';
                 if ($this -> getSql() != false){
                     $opc = urlencode($this -> sql);
                     $opc = "&sql=" . "$opc";
                     }

                 $curl = new Sabv_Relatorio_Util_MyCurl();
                 $curl -> setUrl("$this->servlet_url");
                 $curl -> setParametros("$fixos" . "$opc");
                 if ($curl -> post()){
                     return true;
                     }
                else{
                     $this -> setMensagemErro($curl -> getMensagemErro(), ERRO_SERVLET);
                     return false;
                     }
                 }
            else{
                 return false;
                 }
             break;
         case 'get':
             if ($this -> verificaParametrosObrigatorios()){
                 $param = $this -> formataParametros("&");

                 $fixos = "&down=" . "$this->down" . "&ponte=get" . "&tipo=" . "$this->tipo";
                 $fixos = "$fixos" . "&nome_arquivo=" . "$this->nome_arquivo";

                 if ($this -> getTipo() == "html"){
                     $fixos = $fixos . "&html_page_break=" . "{$this->html_page_break}";
                     }

                 $opc = "$param";
                 if ($this -> getSql() != false){
                     $opc = "$opc" . "&sql=" . urlencode($this -> sql);
                     }

                 $tmp = new MyCurl();
                 $tmp -> setUrl("$this->servlet_url");
                 $tmp -> setParametros("$opc" . "$fixos");
                 if ($tmp -> get()){
                     return true;
                     }
                else{
                     $this -> setMensagemErro($tmp -> getMensagemErro(), ERRO_SERVLET);
                     return false;
                     }
                 }
            else
                 return false;
             break;

         default:
             $this -> setMensagemErro("Ponte inválida");
             return false;
             break;
             }
         }
    }
