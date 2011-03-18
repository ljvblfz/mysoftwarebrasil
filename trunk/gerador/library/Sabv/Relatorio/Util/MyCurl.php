<?php



require_once 'ValidateUrl.php';


function trataHeader($ch, $linhaHeader)
{
     $length = strlen($linhaHeader);
     if ((stripos($linhaHeader, 'Content-Type') !== false) ||
             (stripos($linhaHeader, 'Content-Disposition') !== false) ||
             (stripos($linhaHeader, 'Expires') !== false) ||
             (stripos($linhaHeader, 'Cache-Control') !== false) ||
             (stripos($linhaHeader, 'Pragma') !== false) ||
             (stripos($linhaHeader, 'Content-Transfer-Encoding') !== false)){
         header($linhaHeader, true);
         }
     return $length;
    }


class Sabv_Relatorio_Util_MyCurl{

     private $msg_erro = 'Não ocorreu nenhum erro!';

     private $url = '';

     private $param = '';


     private function setMensagemErro($msg)
    {
         if (is_string($msg)){
             $this -> msg_erro = $msg;
             return true;
             }
        else
             return false;
         }


     public function getMensagemErro()
    {
         return $this -> msg_erro;
         }


     public function setUrl($url)
    {
         if (Sabv_Relatorio_Util_ValidateUrl :: validateUrlSyntax($url, 'p?')){
             $this -> url = $url;
             return true;
             }else{
             $this -> setMensagemErro("Url invalida");
             return false;
             }
         }


     public function setParametros($param)
    {
         if (is_string($this -> param)){
             $this -> param = $param;
             return true;
             }
        else{
             $this -> setMensagemErro("Parametros inválidos");
             return false;
             }
         }


     public function post($retorna_output = false, $is_html = false)
    {
         if(empty($_ENV['no_proxy'])){
             putenv('no_proxy=' . NO_PROXY);
             }
        else{
             putenv('no_proxy=' . $_ENV['no_proxy'] . ',' . NO_PROXY);
             }

         if (empty($this -> url)){
             $this -> setMensagemErro("Url nao fornecida");
             return false;
             }

         $ch = curl_init();
         curl_setopt($ch, CURLOPT_URL, "$this->url");
         curl_setopt($ch, CURLOPT_POST, 1);
         curl_setopt($ch, CURLOPT_POSTFIELDS, "$this->param");
         if (!$is_html){
             curl_setopt($ch, CURLOPT_HEADERFUNCTION, 'trataHeader');
             }
         curl_setopt($ch, CURLOPT_BINARYTRANSFER, 1);
         curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
         $output = curl_exec ($ch);

         if (strcmp(substr($output, 0, 4), "erro") == 0){ // se as 4 primeiras letras forem igual a "erro"
             $this -> setMensagemErro(substr($output, 5, strlen($output))); //pega a mensagem de erro gerada no servlet
             return false;
             }

         if (curl_errno($ch) != 0){
             $this -> setMensagemErro(curl_error($ch));
             return false;
             }
         curl_close ($ch);

         if ($retorna_output){
             return $output;
             }

         echo $output;
         return true;
         }


     public function get($retorna_output = false, $is_html = false)
    {
         if(empty($_ENV['no_proxy'])){
             putenv('no_proxy=' . NO_PROXY);
             }
        else{
             putenv('no_proxy=' . $_ENV['no_proxy'] . ',' . NO_PROXY);
             }

         if (empty($this -> url)){
             $this -> setMensagemErro("Url nao fornecida");
             return false;
             }

         $ch = curl_init();
         curl_setopt($ch, CURLOPT_URL, "$this->url?" . "$this->param");
         if (!$is_html){
             curl_setopt($ch, CURLOPT_HEADERFUNCTION, 'trataHeader');
             }
         curl_setopt($ch, CURLOPT_BINARYTRANSFER, 1);
         curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1); // return into a variable
         $output = curl_exec ($ch);

         if (strcmp(substr($output, 0, 4), "erro") == 0){ // se as 4 primeiras letras forem igual a "erro"
             $this -> setMensagemErro(substr($output, 5, strlen($output))); //pega a mensagem de erro gerada no servlet
             return false;
             }

         if (curl_errno($ch) != 0){
             $this -> setMensagemErro(curl_error($ch));
             return false;
             }
         curl_close ($ch);
         if ($retorna_output){
             return $output;
             }
         echo $output;
         return true;
         }
    }
?>