<?php
/**
 * Classe utilizada para acessar as funчѕes lib cUrl
 * 
 * @package _sicof
 * @author Eduardo Delano
 * $Id: MyCurl.php,v 1.1 2009/03/25 18:43:02 delano Exp $
 */ 

/**
 * Utiliza a biblioteca para validaчуo da sintaxe de uma URL  
 */ 
require_once 'ValidateUrl.php';

/**
 * Utilizada para tratar os headers recebidos da URL acessada pela lib cUrl
 * 
 * @see Axs_Relatorio_Util_MyCurl::get() , Axs_Relatorio_Util_MyCurl::post()
 * @param string $ch Handler utilizado pela lib cUrl
 * @param string $linhaHeader Header recebido da URL acessada 
 * @return string $tamanho Tamanho da string
 */ 
function trataHeader($ch, $linhaHeader)
{
    $length = strlen($linhaHeader);
    //sѓ reenvia os headers abaixo
    if ((stripos($linhaHeader,'Content-Type') !== false) ||
        (stripos($linhaHeader,'Content-Disposition') !== false)||
		(stripos($linhaHeader,'Expires') !== false)||
		(stripos($linhaHeader,'Cache-Control') !== false)||
		(stripos($linhaHeader,'Pragma') !== false)||
        (stripos($linhaHeader,'Content-Transfer-Encoding') !== false)){                
        header($linhaHeader,true);
    }
    //deve-se retornar sempre o tamanho da string para que a funчуo seja chamada para cada linha do header
    return $length;
}    

/**
 * Classe utilizada para acessar a lib cUrl para que seja possivel utilizar os metodos
 * GET e POST do protocolo HTTP. 
 * 
 * @author Eduardo Delano
 * @package Report
 * 
 */ 
class Axs_Relatorio_Util_MyCurl {
    /**
     * Armazena as mensagens de erro que podem ocorrer durante a execuчуo do script.
     *
     * @var string     
     */
    private $msg_erro      = 'Nуo ocorreu nenhum erro!';
    /**
     * Armazena a URL que serс acessada pela lib cUrl.
     *
     * @var string     
     */    
    private $url           = '';
    /**
     * Armazena os parametros que serуo passados juntos com a URL.
     *
     * @var string     
     */    
    private $param         = '';     
    
    /**
     * Altera a mensagem de erro na var. {@link $this->msg_erro}
     * 
     * @name setMensagemErro
     * @see Axs_Relatorio_Util_MyCurl::$msg_erro
     * @param string $msg Mensagem de erro
     * @acess public
     * @return boolean true se conseguiu atribuir, ou false caso contrсrio.
     */
    private function setMensagemErro($msg)
    {
        if (is_string($msg)) {
            $this->msg_erro = $msg;
            return true;
        }
        else
            return false;        
    } 
    
    /**
     * Recebe a mensagem de erro armazenada na var. {@link  Axs_Relatorio_Util_MyCurl::$msg_erro}.
     * 
     * @name getMensagemErro
     * @see Axs_Relatorio_Util_MyCurl::$msg_erro
     * @acess public
     * @return string Mensagem de erro
     */
    public function getMensagemErro()
    {
        return $this->msg_erro;
    }
    
    /**
     * Altera a URL na var. {@link  Axs_Relatorio_Util_MyCurl::$url}.
     * 
     * @name setUrl
     * @see Axs_Relatorio_Util_MyCurl::$msg_erro
     * @param string $msg Mensagem de erro
     * @acess public
     * @return boolean true se conseguiu atribuir, ou false caso contrсrio.
     */        
    public function setUrl($url)
    {             
        if (Axs_Relatorio_Util_ValidateUrl::validateUrlSyntax($url, 'p?')) {
            $this->url = $url;
            return true;
        } else {
            $this->setMensagemErro("Url invalida");
            return false;
        }         
    }    
        
    /**
     * Adiciona os parametros a serem enviados junto com a URL.
     * 
     * @name setParametros
     * @see Axs_Relatorio_Util_MyCurl::$param
     * @param string $param Parametros a seram enviados
     * @acess public
     * @return boolean true se conseguiu atribuir, ou false caso contrсrio.
     */        
    public function setParametros($param)
    {
        if (is_string($this->param)) {
            $this->param = $param;
            return true;
        }
        else {
            $this->setMensagemErro("Parametros invсlidos");
            return false;
        }
    }

    /**
     * Envia os parametros para URL atravщs do mщtodo POST do protocolo HTTP e exibe o resultado da
     * requisiчуo feita р URL guardada na var. Se o parametro opcional $retorna_output for true, a
	 * saida do servlet щ retornada {@link Axs_Relatorio_Util_MyCurl::$url}. O parametro $is_html true щ utilizado para
	 * indicar que a resposta do servlet щ uma pagina html.
     * 
     * @name post
     * @see Axs_Relatorio_Util_MyCurl::$url, Axs_Relatorio_Util_MyCurl::$param
     * @acess public
     * @return boolean true se conseguiu acessar a url com sucesso, ou false caso contrсrio.
     */            
    public function post($retorna_output=false,$is_html=false)
    {    
        if(empty($_ENV['no_proxy'])){
            putenv('no_proxy='.NO_PROXY);
        }
        else{
            putenv('no_proxy='.$_ENV['no_proxy'].','.NO_PROXY);
        }    
            
        if (empty($this->url)) {
            $this->setMensagemErro("Url nao fornecida");
            return false;
        }
        
        $ch = curl_init();     
        curl_setopt($ch, CURLOPT_URL,"$this->url");
        curl_setopt($ch, CURLOPT_POST, 1);
        curl_setopt($ch, CURLOPT_POSTFIELDS, "$this->param");
		if (!$is_html) {
            curl_setopt($ch, CURLOPT_HEADERFUNCTION, 'trataHeader');		    
		}                            
        //curl_setopt($ch, CURLOPT_HEADER, 1);
        curl_setopt($ch, CURLOPT_BINARYTRANSFER, 1);
        curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1); 
        $output = curl_exec ($ch);
				 
        if (strcmp(substr($output, 0, 4),"erro") == 0) {//se as 4 primeiras letras forem igual a "erro"
            $this->setMensagemErro(substr($output,5,strlen($output)));//pega a mensagem de erro gerada no servlet
            return false;            
        }           
        
        if (curl_errno($ch)!=0){
            $this->setMensagemErro(curl_error($ch));
            return false;
        }  
        curl_close ($ch);
		
		if ($retorna_output) {
		    return $output;
		}
		
        echo $output;
        return true;        
    }
    
    /**
     * Envia os parametros para URL atravщs do mщtodo GET do protocolo HTTP e exibe o resultado da
     * requisiчуo feita р URL guardada na var. Se o parametro opcional $retorna_output for true, a
	 * saida do servlet щ retornada{@link Axs_Relatorio_Util_MyCurl::$url}.O parametro $is_html true щ utilizado para
	 * indicar que a resposta do servlet щ uma pagina html.
     * 
     * @name get
     * @acess public
     * @return boolean true se conseguiu acessar a url com sucesso, ou false caso contrсrio.
     */            
    public function get($retorna_output=false, $is_html=false)
    {    
        if(empty($_ENV['no_proxy'])){
            putenv('no_proxy='.NO_PROXY);
        }
        else{
            putenv('no_proxy='.$_ENV['no_proxy'].','.NO_PROXY);
        }    
            
        //if (empty($this->param)) {
        //    $this->setMensagemErro("Nenhum parametro foi passado");
        //    return false;
        //}
        if (empty($this->url)) {
            $this->setMensagemErro("Url nao fornecida");
            return false;
        }
        
        $ch = curl_init();     
        curl_setopt($ch, CURLOPT_URL,"$this->url?" . "$this->param");
		if (!$is_html) {
		    curl_setopt($ch, CURLOPT_HEADERFUNCTION, 'trataHeader');
		}        
        //curl_setopt($ch, CURLOPT_HEADER, 1);
        curl_setopt($ch, CURLOPT_BINARYTRANSFER, 1);
        curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1); // return into a variable
        $output = curl_exec ($ch);            

        if (strcmp(substr($output, 0, 4),"erro") == 0) {//se as 4 primeiras letras forem igual a "erro"
            $this->setMensagemErro(substr($output,5,strlen($output)));//pega a mensagem de erro gerada no servlet
            return false;            
        }           
        
        if (curl_errno($ch)!=0){
            $this->setMensagemErro(curl_error($ch));
            return false;
        }
        curl_close ($ch);
		if ($retorna_output) {
		    return $output;
		}		
        echo $output;        
        return true;        
    }    
} 
?>