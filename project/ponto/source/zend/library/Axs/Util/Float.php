<?php
/**
 * Classe com m�todos para c�lculos e compara��es num�ricas utilizando BC Math
 * 
 * @name Axs_Util_Float
 * @author Gabriel Palhares 
 * @package _sicof
 * $Id: Float.php,v 1.1 2009/03/25 18:43:16 delano Exp $
 */

// Carregando classes
Zend_Loader::loadClass('Zend_Locale_Math');
Zend_Loader::loadClass('Zend_Locale_Math_PhpMath');
Zend_Loader::loadClass('Zend_Locale');
Zend_Loader::loadClass('Zend_Locale_Exception');
Zend_Loader::loadClass('Zend_Locale_Format');

class Axs_Util_Float {
	/**
	 * Precis�o decimal com que os c�lculos ser�o feitos. Padr�o 5.
	 * 
	 * @name $precisao
	 * @access protected 
	 * @var int 
	 */
	protected $precisao;
	/**
	 * N�mero gravado no em uma string formato 0.00 para facilitar os c�lculos.
	 * 
	 * @name $numero
	 * @access protected 
	 * @var string 
	 */
	protected $numero;
	/**
	 * Grava o n�mero original passado para o objeto.
	 * 
	 * @name $numeroOriginal
	 * @access protected 
	 * @var string|int|float
	 */
	protected $numeroOriginal;

	/**
	 * Separador decimal utilizado
	 * 
	 * @name $separadorDecimal
	 * @access protected 
	 * @var string
	 */	
	protected $separadorDecimal;
	
	/**
	 * Separador milhar utilizado
	 * 
	 * @name $separadorMilhar
	 * @access protected 
	 * @var string
	 */	
	protected $separadorMilhar;

	/**
	 * M�todo construtor. Carrega classes necess�rias para a execu��o da classe, seta o n�mero original
	 * a precis�o e o n�mero.
	 *  
	 * @name __construct
	 * @param string|float|int|object $num
	 * @param int $precisao 
	 * @access public 
	 */
	public function __construct ($num = 0, $precisao = 5, $throwException = false)
	{
		// Busca e seta separadores
		// Setando n�mero original
		$this->numeroOriginal = $num;
		// Setando precis�o
		$this->setPrecisao($precisao);
		$num = trim($num);
		// Se valor for vazio, inicia com 0
		if (empty($num)) {
			$num = "0";
		}

		$sep = Axs_Util_Float::buscaSeparadores();
		$this->separadorDecimal = $sep['separadorDecimal'];
		$this->separadorMilhar = $sep['separadorMilhar'];

		// Coloca 0 se necess�rio para verificar se � num�rico
		if (strpos($num, $this->separadorDecimal) === 0) {
			$num = '0' . $num;
		}
		
		$posSeparadorMilhar = strpos($num, $this->separadorMilhar);
		$posSeparadorDecimal = strpos($num, $this->separadorDecimal);
		if ($posSeparadorDecimal !== false && $posSeparadorMilhar !== false && 
			$posSeparadorDecimal < $posSeparadorMilhar) {
			if ($throwException) {
				throw new Zend_Locale_Exception('Formato inv�lido: separador decimal n�o pode vir antes do separador de milhar');
			} else {
				$num = null;
			}
		}
		
		// Separa o n�mero em parte inteira e decimal
		$arrayNum = explode($this->separadorDecimal, $num);
		if (count($arrayNum) > 2) {
			if ($throwException) {
				throw new Zend_Locale_Exception('Formato inv�lido: n�mero passado possui mais de um separador decimal');
			} else {
				$arrayNum = null;
			}
		}
		
		// Verifica se o n�mero � v�lido atrav�s de n�meros por agrupamento de milhar
		// se ele possuir algum separador
		if (strpos($num, $this->separadorMilhar) !== false) {
			$parteInteira = explode($this->separadorMilhar, $arrayNum[0]);
			foreach($parteInteira as $chave => $valor){
				$strlenValor = strlen($valor);
				if ($strlenValor > 3 || ($strlenValor < 2 && $chave != 0)) {
					if ($throwException) {
						throw new Zend_Locale_Exception('Formato inv�lido');
					} else {
						$arrayNum = null;
						break;
					}
				}
			}
		}
		// Tira separadores de milhar
		$arrayNum[0] = str_replace($this->separadorMilhar, '', $arrayNum[0]);
		// Coloca ponto para verifica��o do is_numeric
		$num = implode('.', $arrayNum); 
		
		if (is_numeric($num)) {
			$this->numero = $this->geraString($num);
		}
	} 
	
	/**
	 * Retorna se o n�mero � v�lido ou n�o
	 * 
	 * @name buscaSeparadores
	 * @access public
	 * @return boolean
	 */		
	public function eNumero() {
		return (isset($this->numero))?true:false;
	}
	
	/**
	 * Busca separadores setados no locale
	 * 
	 * @name buscaSeparadores
	 * @access public
	 * @return array
	 */	
    public static function buscaSeparadores()
    {
        $localeInfo = localeconv();
        if (empty($localeInfo['mon_decimal_point'])) {
            throw new Zend_Locale_Exception('Configura��es regionais n�o encontradas na tentativa de buscar os separadores num�ricos da localiza��o!');
            return false;
        } else {
			$separadores['separadorDecimal'] = $localeInfo['mon_decimal_point'];
			$separadores['separadorMilhar'] = $localeInfo['mon_thousands_sep'];
			return $separadores;
		}
    }
	
	
	/**
	 * Verifica se opera��o deve ou n�o ser executada. Se n�mero n�o estiver setado, retorna false.
	 * 
	 * @name executaOperacao
	 * @access protected
	 * @return boolean
	 */	
	public function executaOperacao () {
		return (isset($this->numero))?true:false;
	}
	
	/**
	 * Formata string num�rica para colocar em $numero, facilitando os c�lculos
	 * 
	 * @name geraString
	 * @param string $num 
	 * @access protected
	 * @return string
	 */
	protected function geraString ($num)
	{
		$num = str_replace('.', ',', $num);
		$num = Zend_Locale_Format::getNumber($num);
		return strval($num);
	}	
	
	/**
	 * Verifica se o par�metro passado � um objeto da inst�ncia Axs_Util_Float ou se � um n�mero comum,
	 * sendo que se for um objeto busca apenas o valor de seu $numero, caso contr�rio retorna o pr�prio
	 * valor passado como par�metro.
	 * 
	 * @name soma
	 * @param string|float|int|object $num 
	 * @access public 
	 * @return string|float|int
	 */
	protected function getParam ($num)
	{
		if (!$num instanceOf Axs_Util_Float) {
			$num = new Axs_Util_Float($num);
		}
		return $num->getNumero(); 
	} 

	/**
	 * Seta a precis�o a ser utilizada nos c�lculos.
	 * 
	 * @name setPrecisao
	 * @param int 
	 * @access public 
	 * @return int
	 */
	public function setPrecisao ($precisao = 5)
	{
		if (!is_numeric($precisao) || strpos($precisao,'.') !== false || strpos($precisao,',') !== false || $precisao < 0) {
			throw new Zend_Exception("Par�metro precis�o precisa ser um n�mero inteiro positivo");
		}

		// Configura o par�metro precisao padr�o para todas as chamadas subsequentes
		$this->precisao = $precisao;
	} 

	/**
	 * Retorna a precis�o configurada como padr�o
	 * 
	 * @name setPrecisao
	 * @access public 
	 * @return int precisao
	 */
	public function getPrecisao ()
	{
		return $this->precisao;
	} 

	/**
	 * Faz a soma do n�mero com o passado por par�metro. Retorna o pr�prio objeto com o total da soma em $numero.
	 * 
	 * @name soma
	 * @param string|float|int|object $num 
	 * @access public 
	 * @return Axs_Util_Float|boolean
	 */
	public function soma ($num)
	{
		if ($this->executaOperacao()) {
			$this->numero = Zend_Locale_Math_PhpMath::Add($this->numero, $this->getParam($num), $this->precisao);
			return $this;
		} else {
			return false;
		}
	} 

	/**
	 * Faz a subtra��o do n�mero com o passado por par�metro. Retorna o pr�prio objeto com a diferen�a da subtra��o em $numero.
	 * 
	 * @name subtrai
	 * @param string|float|int|object $num 
	 * @access public 
	 * @return Axs_Util_Float|boolean
	 */
	public function subtrai ($num)
	{
		if ($this->executaOperacao()) {	
			$this->numero = Zend_Locale_Math_PhpMath::Sub($this->numero, $this->getParam($num), $this->precisao);
			return $this;
		} else {
			return false;
		}
	} 

	/**
	 * Faz a multiplica��o do n�mero com o passado por par�metro. Retorna o pr�prio objeto com o produto da multiplica��o em $numero.
	 * 
	 * @name multiplica
	 * @param string|float|int|object $num 
	 * @access public 
	 * @return Axs_Util_Float|boolean
	 */
	public function multiplica ($num)
	{
		if ($this->executaOperacao()) {
			$this->numero = Zend_Locale_Math_PhpMath::Mul($this->numero, $this->getParam($num), $this->precisao);
			return $this;
		} else {
			return false;
		}
	} 

	/**
	 * Faz a divis�o do n�mero com o passado por par�metro. Retorna o pr�prio objeto com o quociente da divis�o em $numero.
	 * 
	 * @name divide
	 * @param string|float|int|object $num 
	 * @access public 
	 * @return Axs_Util_Float|boolean
	 */
	public function divide ($num)
	{
		if ($this->executaOperacao()) {
			$this->numero = Zend_Locale_Math_PhpMath::Div($this->numero, $this->getParam($num), $this->precisao);
			return $this;
		} else {
			return false;
		}
	} 

	/**
	 * Faz o m�dulo do n�mero de acordo com o valor passado por par�metro. Retorna o pr�prio objeto com o resultado do m�dulo em $numero.
	 * 
	 * @name modulo
	 * @param string|float|int|object $num 
	 * @access public 
	 * @return Axs_Util_Float|boolean
	 */
	public function modulo ($num)
	{
		if ($this->executaOperacao()) {
			$this->numero = Zend_Locale_Math_PhpMath::Mod($this->numero, $this->getParam($num), $this->precisao);
			return $this;
		} else {
			return false;
		}
	} 

	/**
	 * Eleva o n�mero ao valor passado por par�metro. Retorna o pr�prio objeto com o resultado da exponencia��o em $numero.
	 * 
	 * @name eleva
	 * @param string|float|int|object $num 
	 * @access public 
	 * @return Axs_Util_Float|boolean
	 */
	public function eleva ($num)
	{
		if ($this->executaOperacao()) {
			$this->numero = Zend_Locale_Math_PhpMath::Pow($this->numero, $this->getParam($num), $this->precisao);
			return $this;
		} else {
			return false;
		}
	} 

	/**
	 * Eleva o n�mero ao valor passado por par�metro levando em conta o m�dulo. Retorna o pr�prio objeto com o resultado em $numero.
	 * 
	 * @name elevaMod
	 * @param string|float|int|object $num 
	 * @access public 
	 * @return Axs_Util_Float|boolean
	 */
	public function elevaMod($num, $modulo)
	{ 
		if ($this->executaOperacao()) {
			$num = $this->geraString($this->getParam($num));
			$this->numero = bcpowmod($this->numero, $num, $modulo, $this->precisao);
			return $this;
		} else {
			return false;
		}
	} 

	/**
	 * Eleva o n�mero ao valor passado por par�metro. Retorna o pr�prio objeto com o resultado da exponencia��o em $numero.
	 * 
	 * @name raiz
	 * @param string|float|int|object $num Se n�o for informado nenhum valor � feita uma raiz quadrada por padr�o.
	 * @access public 
	 * @return Axs_Util_Float|boolean
	 */
	public function raiz ($num = 2)
	{ 
		if ($this->executaOperacao()) {
			$this->numero = Zend_Locale_Math_PhpMath::Sqrt($this->numero, $this->getParam($num), $this->precisao);
			return $this;
		} else {
			return false;
		}
	} 
	/**
	 * Compara se o n�mero � maior que o n�mero passado por par�metro.
	 * 
	 * @name eMaior
	 * @param string $num
	 * @access public 
	 * @return boolean
	 */
	public function eMaior ($num)
	{
				
		if ($this->executaOperacao()) {
			return (Zend_Locale_Math_PhpMath::Comp($this->numero, $this->getParam($num), $this->precisao) == 1);
		} else {
			return false;
		}
	} 

	/**
	 * Compara se o n�mero � menor que o n�mero passado por par�metro.
	 * 
	 * @name eMenor
	 * @param string $num
	 * @access public 
	 * @return boolean
	 */
	public function eMenor ($num)
	{
		if ($this->executaOperacao()) {	
			return (Zend_Locale_Math_PhpMath::Comp($this->numero, $this->getParam($num), $this->precisao) == -1);
		} else {
			return false;
		}
	} 

	/**
	 * Compara se o n�mero � igual ao n�mero passado por par�metro.
	 * 
	 * @name eMaior
	 * @param string $num
	 * @access public 
	 * @return boolean
	 */
	public function eIgual($num)
	{
		if ($this->executaOperacao()) {
			return (Zend_Locale_Math_PhpMath::Comp($this->numero, $this->getParam($num), $this->precisao) == 0);
		} else {
			return false;
		}
	} 

	/**
	 * Retorna $numero em seu estado atual
	 * 
	 * @name getNumero
	 * @access public 
	 * @return string|boolean
	 */
	public function getNumero()
	{
		return $this->numero;
	} 

	/**
	 * Retorna o valor do n�mero quando este foi instanciado.
	 * 
	 * @name getNumero
	 * @access public 
	 * @return string|float|int
	 */
	public function getNumeroOriginal()
	{
		return $this->numeroOriginal;
	} 

	/**
	 * Retorna o n�mero como Float, de acordo com so par�metros passados.
	 * 
	 * @name getNumero
	 * @param boolean $arredondar Flag que determina se o n�mero deve ou n�o ser arredondado ao truncar, de acordo com o n�mero de casas
 	 * @param int $casasDecimais N�mero de casas decimais do n�mero. Se n�o setado pega de acordo com a precis�o.
	 * @param string $locale Locale padr�o para a m�scara utilizada, utilizando ponto (.) como separador decimal
	 * @access public 
	 * @return float|boolean
	 */
	public function getFloat ($arredondar = false, $casasDecimais = null, $locale = 'pt_BR')
	{
		if ($this->executaOperacao()) {
			// Se n�o estiver setado casas decimais pega de acordo com a precis�o
			if (!isset($casasDecimais)) {
				$casasDecimais = $this->precisao;
			} 
			// Arredonda o n�mero caso o par�metro $arrendondar seja true, de acordo com as casas decimais desejadas
			// se n�o arredondar atribui a $num, substituindo ponto por v�rgula
			($arredondar)?$num=round($this->numero, $casasDecimais):$num=str_replace('.', ',', $this->numero);
			
			// Se $num n�o for float ou se o locale for diferente de 'de_AT', um novo locale precisa ser informado e o float
			// formatado de acordo com ele. 
			if (!is_float($num) || $locale != 'pt_BR') {
				$num = Zend_Locale_Format::getFloat($num, array('precision' => $casasDecimais, 'locale' => $locale));
			}
			return $num;
		} else {
			return false;
		}
	} 

	/**
	 * M�todo m�gico que retorna a string formatada do n�mero quando objeto usado em contexto de string
	 * 
	 * @return String
	 */
	public function __toString() {
		return Axs_Util_Float::formataNumero($this->numero);
	}	

	/**
	 * Retorna o n�mero como Float, de acordo com so par�metros passados.
	 * 
	 * @name formataNumero
	 * @param float|int|string|object N�mero a ser formatado 
	 * @param boolean $arredondar Flag que determina se o n�mero deve ou n�o ser arredondado ao truncar, de acordo com o n�mero de casas
	 * @param int $casasDecimais N�mero de casas decimais do n�mero
	 * @param string $separadorDecimal String que determina o separador decimal do n�mero 
	 * @access public
	 * @return string
	 */		
	public static function formataNumero ($num, $casasDecimais = 2, $arredondar = false, $separadorDecimal = null, $separadorMilhar = null) {
		
		if (empty($num)) {
			$num = 0;
		}	
		// Se n�o tiver setado separador decimal nem milhar, busca do locale
		if (!isset($separadorMilhar) || !isset($separadorDecimal)) {
			$arraySeparadores = Axs_Util_Float::buscaSeparadores();
			if (!isset($separadorDecimal)) {
				$separadorDecimal = $arraySeparadores['separadorDecimal']; 
			}
			if (!isset($separadorMilhar)) {
				$separadorMilhar = $arraySeparadores['separadorMilhar']; 
			}
		}
		
		// Verifica se par�metro passado � inst�ncia da classe
		if (!($num instanceOf Axs_Util_Float)) {
			$num = new Axs_Util_Float($num, $casasDecimais);
		}
		// Pega o n�mero passado do objeto
		$num = $num->getNumero();
				
		// Apenas executa o resto das rotinas se valor passado � num�rico 
		if (is_numeric($num)) {
			// Se n�o for para arredondar, formata "manualmente"
			if ($arredondar == false) {
	
				$arrayNum = explode('.', $num);
				// Se n�meros estiverem vazios, coloca zero
				if (empty($arrayNum[0])) {
					$arrayNum[0] = "0";
				}
				
				// Formata apenas parte inteira com separador milhar
				$arrayNum[0] = number_format($arrayNum[0], 0, '', $separadorMilhar);
				
				// Coloca zeros de acordo com n�mero de casas decimais
				if (isset($arrayNum[1])) {
					$decimalLength = intval(strlen($arrayNum[1]));
				} else {
					// Inicia vars para n�o dar notice (undefined), caso vazio
					$decimalLength = 0;
					$arrayNum[1] = "";
				}
				if ($decimalLength < $casasDecimais) {
					for ($i=$decimalLength;$i<$casasDecimais;$i++) {
						$arrayNum[1] .= "0";
					}
					$parteDecimal = $arrayNum[1];
				} else {
					// Se n�o for 0, corta parte decimal de acordo com o n�mero casas decimais
					$parteDecimal = substr($arrayNum[1], 0, $casasDecimais);
				}				
				return trim($arrayNum[0] . $separadorDecimal . $parteDecimal, $separadorDecimal);
			} else {
				// Caso contr�rio formata com number_format
				return number_format($num, $casasDecimais, $separadorDecimal, $separadorMilhar);
			}
		}
	}

} 

?>