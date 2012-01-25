<?php
/**
 * Classe utilizada como interface para o servlet que gera relat�rios
 * 
 * @package _sicof
 * @author Eduardo Delano
 * @requires ValidateUrl.php, MyCurl.php
 * $Id: Request.php,v 1.1 2009/03/25 18:42:45 delano Exp $
 */

require_once 'Axs/Relatorio/Util/ValidateUrl.php';
require_once 'Axs/Relatorio/Util/MyCurl.php';

/** 
 * Erro gerado por um script php
 */ 
define("ERRO_PHP",0);

/**
 * Erro gerado pelo servlet
 */
define("ERRO_SERVLET",1);

/**
 * URI do servlet de informa��es do banco de dados
 */
define("SERVLET_DB","/dburl"); 
 
/**
 * Classe utilizada como interface para acessar o servlet responsavel pela gera��o dos relat�rios.
 * O servlet pode receber os parametros para gerar o relat�rio atrav�s do banco de dados, atrav�s
 * do m�todo POST ou m�todo GET do protocolo HTTP.
 * 
 * @author Eduardo Delano
 * @acess public
 */ 
class Axs_Relatorio_Request {
    /**
     * Variavel setada quando ocorre algum erro
     * 
     * @see ERRO_PHP, ERRO_SERVLET, Axs_Relatorio_Request::$tipo_erro, Axs_Relatorio_Request::$msg_erro 
     * @var boolean 
     */
     private $ocorreu_erro = false;
      
    /** 
     * Armazena o tipo de erro que ocorreu.
     * 
     * @see ERRO_PHP, ERRO_SERVLET  
     * @var integer     
     */
    private $tipo_erro = '';

    /** 
     * Armazena a mensagem de erro.
     * 
     * @var string
     */
    private $msg_erro = 'N�o ocorreu nenhum erro!';
     
    /** 
     * Armazena os tipos de pontes v�lidas.
     * 
     * @var array     
     */    
    private $pontes_validas = ''; 
    
    /** 
     * Armazena os tipos de arquivos v�lidos.
     * 
     * @var array 
     */     
    private $tipos_validos = ''; 
        
    /** 
     * Armazena a url do servlet.
     * 
     * @var string 
     */ 
    private $servlet_url = ''; 

    /** 
     * Armazena a url do servlet que retorna as informa�oes do Banco utilizado pelo servlet.
     * 
     * @var string 
     */ 
    private $servlet_bd_url = ''; 
		
    /** 
     * Armazena o tipo de ponte utilizada.
     * 
     * @see Axs_Relatorio_Request::$pontes_validas
     * @var string 
     */     
    private $ponte = ''; 
    
    /** 
     * Armazena o tipo de arquivo do rerlatorio. 
     * 
     * @see Axs_Relatorio_Request:$tipos_validos
     * @var string 
     */ 
    private $tipo = ''; 
    
    /** 
     * Armazena o nome do arquivo jasper sem a extens�o ".jasper" 
     * 
     * @see $nomes_arquivos_validos
     * @var string  
     */ 
    private $nome_arquivo = ''; 
    
    /** 
     * Armazena a query SQL passada como parametro para o relatorio 
     * 
     * @var string 
     */  
    private $sql = '';
     
    /** 
     * Armazena o codigo do relat�rio armazenado no banco de dados. 
     * 
     * @var integer 
     */ 
    private $cod_rel = ''; 
    
    /** 
     * Armazena todos os parametros que n�o s�o obrigat�rios. 
     * 
     * @var array 
     */ 
    private $param = array(); 
        
    /** 
     * Armazena o valor do parametro down passado para o servlet. 
     * 0 - Utilizado para que o browser tente abrir o rel�t�rio pelo aplicativo padr�o. 
     * 1 - Valor padr�o, utilizado para que o download do relat�rio seja feito sempre. 
     * 
     * @var integer  
     */ 
    private $down = 0;
    
    /** 
     * Armazena o valor do parametro down passado para o servlet. 
     * true  - Relat�rio em html com quebra de pagina. 
     * false - Relat�rio em html sem quebra de pagina. 
     * 
     * @var boolean  
     */ 
    public $html_page_break = true;
	
    /**
     * M�todo construtor da classe.  
     */ 
    function __construct()
    {
        $this->pontes_validas = array("post", "get");
        $this->tipos_validos = array("pdf", "html", "csv", "xls", "xml");
    } 

    /** 
     * Altera a mensagem de erro na var. {@link Axs_Relatorio_Request::$msg_erro} e o tipo de erro.
     * Caso nenhum parametro de tipo de erro seja passado, o tipo padr�o ser� ERRO_PHP.
     * Para erros gerados pelo servlet a constante ERRO_SERVLET deve ser utilizada. 
     * 
     * @name setMensagemErro
     * @see ERRO_PHP, ERRO_SERVLET
     * @param string $msg Mensagem de erro
     * @param int $tipo ERRO_PHP, ERRO_SERVLET
	 * @acess private 
     * @return boolean true se conseguiu atribuir, ou false caso contr�rio.
     */        
    private function setMensagemErro($msg, $tipo = ERRO_PHP)
    {
        if (is_string($msg) && is_int($tipo)) {
            $this->msg_erro = $msg;
            $this->tipo_erro = $tipo;                    
            return true;
        }
        else
            return false;
    } 

    /** 
     * Retorna a mensagem de erro armazenada na var. {@link Axs_Relatorio_Request::$msg_erro}.
     * 
     * @name getMensagemErro
     * @acess public
     * @return string $mensagem Mensagem de erro.
     */            
    public function getMensagemErro()
    {
        return $this->msg_erro;
    }
     
    /** 
     * Retorna o tipo de erro armazenado na var. {@link Axs_Relatorio_Request::$tipo_erro}.
     * 
     * @name getTipoErro
     * @see ERRO_PHP, ERRO_SERVLET
     * @acess public
     * @return integer $tipo Tipo de erro.
     */                
    public function getTipoErro()
    {
        return $this->tipo_erro;   
    }

    /** 
     * Altera o tipo de ponte utilizada para acessar o servlet
     * 
     * @name setPonte
     * @see Axs_Relatorio_Request::$pontes_validas
     * @param string $ponte Ponte utilizada
     * @acess public
     * @return boolean true se conseguiu atribuir, ou false caso contr�rio.
     */            
    public function setPonte($ponte)
    {
        if (in_array($ponte, $this->pontes_validas)) {
            $this->ponte = $ponte;
            return true;
        } else {
            if (!$this->ocorreu_erro) {
                $this->setMensagemErro("Ponte invalida");
                $this->ocorreu_erro = true;                
            }
            return false;
        } 
    } 

    /** 
     * Altera a URL utilizada para acessar o servlet.
     * 
     * @name setServletUrl
     * @param string $url URL do servlet.
     * @acess public
     * @return boolean true se conseguiu atribuir, ou false caso contr�rio.
     */            
    public function setServletUrl($url)
    {
        if (Axs_Relatorio_Util_ValidateUrl::validateUrlSyntax($url, 'p?')) {
            $this->servlet_url = $url;
			$this->servlet_bd_url = $this->getServletBDUrl($url);
            return true;
        } 
		else {
            if (!$this->ocorreu_erro) {
                $this->setMensagemErro("Url invalida");
                $this->ocorreu_erro = true;
            }    
            return false;
        } 
    } 

	/**
	 * A partir da url do servlet, retira a url-pattern do servlet de relatorios e
	 * adiciona a url-pattern do servlet de inform��es do banco de dados 
	 * 
	 * @name getServletBDUrl
	 * @param string $url URL do servlet.
	 * @acess private
     * @return string A URL do servlet
	 */ 
	private function getServletBDUrl($url_servlet_bd)
	{
        //separa a URL em duas partes a partir da string //
		$parte1 = explode("//", $url_servlet_bd);
		//pega o que vem depois do // e separa a string a partir do caractere /
        $parte2 = explode("/", $parte1[1]);
		
        $num = count($parte2)-1;		
        $str_tmp = "";
        for ($i=0; $i<$num; $i++) {
            if ($str_tmp == "") {
                $str_tmp = $parte2[$i];
            }
            else {
        	    $str_tmp = $str_tmp."/".$parte2[$i];
        	}
        }		
        $servlet_db = "http://".$str_tmp.SERVLET_DB;
		
		return $servlet_db;
    }
	
    /** 
     * Retorna a URL utilizada para acessar o servlet.
     * 
     * @name getServletUrl
     * @acess public
     * @return boolean/string false se n�o conseguir ou a string com a URL do servlet.
     */                
    public function getServletUrl()
    {
        if (strcmp($this->servlet_url, '') != 0)
            return $this->servlet_url;
        else {
            if (defined('SERVLET_RELATORIO')) {
                $this->setServletUrl(SERVLET_RELATORIO);
                return $this->servlet_url;
            }
            else if (!$this->ocorreu_erro) {                
                $this->setMensagemErro("Url do servlet nao inicializada");
                $this->ocorreu_erro = true;
            }    
            return false;
        } 
    } 

    /**
     * Retorna a ponte utilizada para acessar o servlet.
     * 
     * @return boolean/string false se n�o conseguir ou a string com ponte utilizada.
     */            
    public function getPonte()
    {
        if (strcmp($this->ponte, '') != 0)
            return $this->ponte;
        else {
            if (!$this->ocorreu_erro) {
                $this->setMensagemErro("Ponte nao inicializada");
                $this->ocorreu_erro = true;
            }    
            return false;
        } 
    } 

    /** 
     * Altera o tipo de arquivo utilizada como fromato do relat�rio.
     * 
     * @see Axs_Relatorio_Request::$tipos_validos
     * @param string $tipo Tipo utilizado.
     * @return boolean true se conseguiu atribuir, ou false caso contr�rio.
     */    
    public function setTipo($tipo, $page_break=true)
    {
        if (in_array($tipo, $this->tipos_validos) && (is_bool($page_break))) {
            $this->tipo = $tipo;
			if ($page_break) {
			    $this->html_page_break = "true";
			}
			else {
			    $this->html_page_break = "false";
			}   
            return true;
        } else {
            if (!$this->ocorreu_erro) {
			    if (!in_array($tipo, $this->tipos_validos)) {
			        $this->setMensagemErro("Tipo invalido");
			    }
				else {
				    $this->setMensagemErro("O par�metro html_page_break deve ser um booleano");
				}                
                $this->ocorreu_erro = true;
            }    
            return false;
        } 
    } 

    /** 
     * Retorna o tipo de arquivo utilizado para se gerar o relat�rio. 
     * 
     * @see Axs_Relatorio_Request::$tipos_validos
     * @return boolean/string false se n�o conseguir ou a string com o tipo utilizado.
     */ 
    public function getTipo()
    {
        if (strcmp($this->tipo, '') != 0)
            return $this->tipo;
        else {
            if (!$this->ocorreu_erro) {            
                $this->setMensagemErro("Tipo nao inicializado");
                $this->ocorreu_erro = true;
            }    
            return false;
        } 
    } 

    /** 
     * Altera o nome do arquivo jasper utilizado para gerar o relat�rio. 
     * 
     * @see Axs_Relatorio_Request::$nomes_arquivos_validos
     * @param string $nome Nome do arquivo.
     * @return boolean true se conseguiu atribuir, ou false caso contr�rio.
     */ 
    public function setNomeArquivo($nome)
    {
        if (is_string($nome)) {
            $this->nome_arquivo = $nome;
            return true;
        } else {
            if (!$this->ocorreu_erro) {
                $this->setMensagemErro("Nome de arquivo jasper invalido");
                $this->ocorreu_erro = true;
            }    
            return false;
        } 
    } 

    /** 
     * Retorna o nome do arquivo jasper utilizado para gerar o relatorio. 
     * 
     * @see Axs_Relatorio_Request::nomes_arquivos_validos
     * @return boolean/string falso se n�o conseguir ou a string com o nome do arquivo.
     */ 
    public function getNomeArquivo()
    {
        if (strcmp($this->nome_arquivo, '') != 0)
            return $this->nome_arquivo;
        else {
            if (!$this->ocorreu_erro) {
                $this->setMensagemErro("Nome de arquivo jasper nao inicializado");
                $this->ocorreu_erro = true;
            }    
            return false;
        } 
    } 

    /** 
     * Altera o valor da query SQL passada como parametro opcional para o servlet. 
     * 
     * @param string $query Query no formato SQL.
     * @return boolean true se conseguiu atribuir, ou false caso contr�rio.
     */ 
    public function setSql($query)
    {
        if (is_string($query)) {
            $this->sql = $query;
            return true;
        } else {
            if (!$this->ocorreu_erro) {
                $this->setMensagemErro("Query invalida");
                $this->ocorreu_erro = true;
            }    
            return false;
        } 
    } 

    /** 
     * Retorna o valor da query SQL passada como parametro opcional para o servlet. 
     * @return boolean/string falso se n�o conseguir ou a string com a query.
     */ 
    public function getSql()
    {
        if (strcmp($this->sql, '') != 0)
            return $this->sql;
        else {
            if (!$this->ocorreu_erro) {
                $this->setMensagemErro("Query nao inicializada");
                $this->ocorreu_erro = true;
            }    
            return false;
        } 
    } 

    /** 
     * Altera o valor do c�digo do relat�rio utilizado caso a ponte seja "bd". 
     * 
     * @param int $cod_rel C�digo do relat�rio.
     * @return boolean true se conseguiu atribuir, ou false caso contr�rio.
     */ 
    public function setCodRel($cod_rel)
    {
        if (is_int($cod_rel)) {
            $this->cod_rel = $cod_rel;
            return true;
        } else {
            if (!$this->ocorreu_erro) {
                $this->setMensagemErro("Codigo de relatorio invalido");
                $this->ocorreu_erro = true;
            }    
            return false;
        } 
    } 
   
    /** 
     * Altera o valor de down.
     * 0 - Valor padr�o. Abre o arquivo no aplicativo padr�o.
     * 1 - faz o download do arquivo.   
     * 
     * @see Axs_Relatorio_Request::$down  
     * @param int $tmp Valor de down.
     * @return boolean true se conseguiu atribuir, ou false caso contr�rio.
     */ 
    public function setDown($tmp)
    {
        if (($tmp == 0) || ($tmp == 1)) {
            $this->down = $tmp;
            return true;
        } else {
            if (!$this->ocorreu_erro) {
                $this->setMensagemErro("Parametro de download invalido");
                $this->ocorreu_erro = true;
            }    
            return false;
        } 
    } 
    
    /** 
     * Retorna o valor guardado na var. Axs_Relatorio_Request::$down 
     * 
     * @see Axs_Relatorio_Request::$down
     * @return boolean/int falso se n�o conseguir ou o inteiro com o valor de down.
     */ 
    public function getDown()
    {
        if (($this->down == 0) || ($this->down == 1)) {
            return $this->down;
        } else {
            if (!$this->ocorreu_erro) {
                $this->setMensagemErro("Parametro de download invalido");
                $this->ocorreu_erro = true;
            }    
            return false;
        } 
    } 

    /** 
     * Adiciona algum parametro ao array Axs_Relatorio_Request::$param
     * 
     * @see Axs_Relatorio_Request::$param
     * @param string $nome Nome do parametro.
     * @param string $valor Valor do parametro.
     * @return boolean true se conseguiu atribuir, ou false caso contr�rio.  
     * @todo M�todo que remove parametro(s) do array. 
     */ 
    public function setParam($nome, $valor)
    {
        $tmp = urlencode($valor);
        if (Axs_Relatorio_Util_ValidateUrl::validateUrlSyntax("www.teste.com?" . "$nome" . "=" . "$tmp", '')) {
            $this->param[$nome] = $valor;
            return true;
        } else {
            if (!$this->ocorreu_erro) {
                $this->setMensagemErro("Parametro invalido");
                $this->ocorreu_erro = true;
            }    
            return false;
        } 
    } 

    /** 
     * Retorna o array com os parametros.  
     *  
     * @return boolean/array falso se n�o conseguir ou o array de strings com os parametros. 
     */ 
    public function getParam()
    {
        if ((count($this->param) > 0)) {
            return $this->param;
        } else {
            if (!$this->ocorreu_erro) {
                $this->setMensagemErro("Parametro(s) nao inicializado(s)");
                $this->ocorreu_erro = true;
            }    
            return false;
        } 
    } 

    /** 
     * M�todo para formatar os parametros da seguinte forma:
     * param1=valor1,param2=valor2,param3=valor3  
     * O caractere "," (v�rgula) � utilizado como separador padr�o.
     * 
     * @param $separador Caractere usado para separar os parametros.  
     * @return boolean true se conseguiu atribuir, ou false caso contr�rio.   
     */ 
    private function formataParametros($separador = ",")
    {
        $tmp = '';
        reset($this->param);
        while (list($key, $value) = each($this->param)) {
            if (strcmp($separador,"&") == 0) {
                $value = urlencode($value);
                $tmp = "$tmp" . "$key" . "=" . "$value" . "$separador";
            }
            else
                $tmp = "$tmp" . "$key" . "=" . "$value" . "$separador";
        } 
        $tmp = substr($tmp, 0, strlen($tmp)-1);
        return $tmp;
    } 
    
    /** 
     * Verifica se todos os parametros obrigat�rios da ponte armazenada na var. Axs_Relatorio_Request::$ponte
     * est�o com seus valores armazenados. 
     * 
     * @return boolean true se todos os parametros obrigatorios estiverem com valores v�lidos ou false caso nenhuma ponte esteja armazenado na var. Axs_Relatorio_Request::$ponte ou se algum parametro obrigat�rio nao possuir valor.
     */ 
    private function verificaParametrosObrigatorios()
    {
        if (strcmp($this->ponte, "post") == 0) {
            if ($this->getServletUrl() == false ) {
                return false;
            }else if ($this->getNomeArquivo() == false) {
                return false;
            } else if ($this->getTipo() == false) {
                return false;
            } else if ($this->getParam() == false) {
                return false;
            } else {
                return true;
            } 
        } 
        if (strcmp($this->ponte, "get") == 0) {
            if ($this->getServletUrl() == false ) {
                return false;
            }else if ($this->getNomeArquivo() == false) {
                return false;
            } else if ($this->getTipo() == false) {
                return false;
            } else if ($this->getParam() == false) {
                return false;
            } else {
                return true;
            } 
        }
        return false; //se nao existir nenhuma ponte 
    } 

    /** 
     * Fun��o utilizada para tratar os dados recebidos do servlet que retorna irforma�oes sobre o
	 * banco de dados. Caso ocorra algum erro na comunica��o com o servlet ou os dados de login e
	 * url do banco utilizados no servlet sejam diferentes dos dados contidos na constante $GLOBALS['dsn'],
	 * mensagens de aviso s�o retornadas para o usu�rio
	 * 
	 * @param string $md5 Resposta vinda do servlet.
     * @return string/boolean Mensagem do erro ocorrido ou false caso os dados estejam coerentes.
     */ 
    private function trataDadosServletBD($md5)
    {
        $md5_banco = explode(":",$md5);
          
        //se a primeira parte da string retornada do sorvlet n�o for a palavra "OK", occoreu um erro
        if ($md5_banco[0] != 'OK') {
            $resposta = "N�o foi poss�vel obter as informa��es sobre o Banco de Dados utilizado pelo Servlet.\n A conex�o com o banco de dados pode n�o ser bem sucedida.";
        }
        else {
            //$dadosConexao = MyDB::parseDSN($GLOBALS['dsn']);
            
			$urlConexao = $dadosConexao['hostspec']. (($dadosConexao['port']==false)?'':':'.$dadosConexao['port']) . '/' . $dadosConexao['database'];
			$md5_php = array(md5($dadosConexao['username']),md5($urlConexao));
			                    
            if (strcmp(trim($md5_banco[1]),trim($md5_php[0]))!= 0) {
                $resposta = "O usu�rio do banco de dados do Servlet � diferente do usu�rio atual.\n Os dados podem n�o ser obtidos corretamente.";
            }
            elseif (strcmp(trim($md5_banco[2]),trim($md5_php[1]))!= 0) {
                $resposta = "A URL de acesso ao Banco de Dados do Servlet � diferente da URL atual.\n Os dados retornados podem ser diferente do esperado.";
            }
			else {
			    $resposta = false; // as informa��es est�o coerentes
			}
        }
		return $resposta;
    }
	
    /** 
     * Fun��o utilizada para mostrar um dialogo de aviso caso o usuario e/ou url de conexao com o banco de dados
	 * do SAFCI e do Servlet sejam diferentes. Se os dados de acesso ao banco forem iguais, nenhum dialogo � exibido.
	 * 
	 * @name confirmaRel
	 * @acess public
     * @return string/boolean Mensagem do erro ocorrido ou false caso os dados estejam coerentes.
     */ 	
	public function confirmaRel() {
 		/*$info_bd = new Axs_Relatorio_Util_MyCurl();
    	$info_bd->setUrl("$this->servlet_bd_url");
   		$md5_banco = $info_bd->post(true);
   		$dadosDiferentes = $this->trataDadosServletBD($md5_banco);
   		if ($dadosDiferentes) { 
   	        //se n�o conseguiu acessar o servlet, o tomcat retorna sua p�gina de erro com codifica��o utf-8. Assim, altera os caracteres acentuados e outros especiais.
    	    //Para contornar o problema, for�o o envio de um header com a codifica��o correta para substituir qualquer uma anterior.
            //header('Content-Type: text/html; charset=iso-8859-1');
            //Dialogo::informa($dadosDiferentes . "\n Para continuar, clique em OK ou acione outro menu para cancelar essa opera��o.", 'alerta');
            return false;
    	}*/
	    return true;
	}

	/** 
     * M�todo utilizado para acessar o servlet atrav�s das fun�es da classe MyCurl e gerar o relat�rio atrav�s
     * dos parametros obrigat�rios, opcionais e da ponte utilizada. 
     * 
     * Caso a ponte seja "bd", existe a possibilidade dos dados do relatorio serem inseridos no banco de dados
     * atrav�s do script php e n�o serem apagados caso ocorra alguma excess�o dentro do servlet, podendo
     * assim ocasionar um erro de viola��o de restri��o de chave prim�ria 
     * 
	 * @param boolean $mostraDialogo Se false nao mostra nenhum aviso quando os dados do banco do SAFCI e do Servlet sao diferentes.
     * @return boolean true se tudo ocorrer bem, ou false caso ocorra algum erro.     
     */ 
    public function mostraRel($mostraDialogo=true)
    {
		if ($mostraDialogo) {		    		
			$this->confirmaRel();
		}	
		
        switch ($this->ponte) {
            case 'post':                
                // obrigatorios:$ponte,$nome_arquivo,$tipo,$param,$down ***cod_rel � ignorado
                // opcionais:$sql
                // *************************************
                if ($this->verificaParametrosObrigatorios()) {
                    $param = $this->formataParametros("&");

                    $fixos = "ponte=post" . "&tipo=" . "$this->tipo" . "&nome_arquivo=";
                    $fixos = "$fixos" . "$this->nome_arquivo" . "&down=" . "$this->down" . "&$param";
					
					if ($this->getTipo()=="html") {
					    $fixos = $fixos."&html_page_break="."{$this->html_page_break}";
					}					
					
                    $opc = '';
                    if ($this->getSql() != false) {
                        $opc = urlencode($this->sql);
                        $opc = "&sql=" . "$opc";
                    } 
					
                    $curl = new Axs_Relatorio_Util_MyCurl();
                    $curl->setUrl("$this->servlet_url");
                    $curl->setParametros("$fixos" . "$opc");
                    if ($curl->post()) {
                        return true;
                    }
                    else {
                        $this->setMensagemErro($curl->getMensagemErro(),ERRO_SERVLET);
                        return false;
                    }
                }
                else {
                    return false;
                } 
                break;
            case 'get': 
                // obrigatorios:$ponte,$nome_arquivo,$tipo,$param, $down ***cod_rel � ignorado
                // opcionais:$sql
                // *************************************
                if ($this->verificaParametrosObrigatorios()) {
                    $param = $this->formataParametros("&");

                    $fixos = "&down=" . "$this->down" . "&ponte=get" . "&tipo=" . "$this->tipo";
                    $fixos = "$fixos" . "&nome_arquivo=" . "$this->nome_arquivo";

					if ($this->getTipo()=="html") {
					    $fixos = $fixos."&html_page_break="."{$this->html_page_break}";
					}										
					
                    $opc = "$param";
                    if ($this->getSql() != false) {
                        $opc = "$opc" . "&sql=" . urlencode($this->sql);
                    } 
                    
                    $tmp = new MyCurl();
                    $tmp->setUrl("$this->servlet_url");
                    $tmp->setParametros("$opc" . "$fixos");
                    if ($tmp->get()) {
                        return true;
                    }
                    else {
                        $this->setMensagemErro($tmp->getMensagemErro(),ERRO_SERVLET);
                        return false;
                    }
                }
                else
                    return false;
                break;

            default:
                $this->setMensagemErro("Ponte inv�lida");                
                return false;
                break;
        } 
    } 
}