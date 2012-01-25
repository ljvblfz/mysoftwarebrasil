<?php
/**
 * Classe com métodos para cálculos e comparações numéricas utilizando BC Math
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
	 * Precisão decimal com que os cálculos serão feitos. Padrão 5.
	 * 
	 * @name $precisao
	 * @access protected 
	 * @var int 
	 */
	protected $precisao;
	/**
	 * Número gravado no em uma string formato 0.00 para facilitar os cálculos.
	 * 
	 * @name $numero
	 * @access protected 
	 * @var string 
	 */
	protected $numero;
	/**
	 * Grava o número original passado para o objeto.
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
	 * Método construtor. Carrega classes necessárias para a execução da classe, seta o número original
	 * a precisão e o número.
	 *  
	 * @name __construct
	 * @param string|float|int|object $num
	 * @param int $precisao 
	 * @access public 
	 */
	public function __construct ($num = 0, $precisao = 5, $throwException = false)
	{
		// Busca e seta separadores
		// Setando número original
		$this->numeroOriginal = $num;
		// Setando precisão
		$this->setPrecisao($precisao);
		$num = trim($num);
		// Se valor for vazio, inicia com 0
		if (empty($num)) {
			$num = "0";
		}

		$sep = Axs_Util_Float::buscaSeparadores();
		$this->separadorDecimal = $sep['separadorDecimal'];
		$this->separadorMilhar = $sep['separadorMilhar'];

		// Coloca 0 se necessário para verificar se é numérico
		if (strpos($num, $this->separadorDecimal) === 0) {
			$num = '0' . $num;
		}
		
		$posSeparadorMilhar = strpos($num, $this->separadorMilhar);
		$posSeparadorDecimal = strpos($num, $this->separadorDecimal);
		if ($posSeparadorDecimal !== false && $posSeparadorMilhar !== false && 
			$posSeparadorDecimal < $posSeparadorMilhar) {
			if ($throwException) {
				throw new Zend_Locale_Exception('Formato inválido: separador decimal não pode vir antes do separador de milhar');
			} else {
				$num = null;
			}
		}
		
		// Separa o número em parte inteira e decimal
		$arrayNum = explode($this->separadorDecimal, $num);
		if (count($arrayNum) > 2) {
			if ($throwException) {
				throw new Zend_Locale_Exception('Formato inválido: número passado possui mais de um separador decimal');
			} else {
				$arrayNum = null;
			}
		}
		
		// Verifica se o número é válido através de números por agrupamento de milhar
		// se ele possuir algum separador
		if (strpos($num, $this->separadorMilhar) !== false) {
			$parteInteira = explode($this->separadorMilhar, $arrayNum[0]);
			foreach($parteInteira as $chave => $valor){
				$strlenValor = strlen($valor);
				if ($strlenValor > 3 || ($strlenValor < 2 && $chave != 0)) {
					if ($throwException) {
						throw new Zend_Locale_Exception('Formato inválido');
					} else {
						$arrayNum = null;
						break;
					}
				}
			}
		}
		// Tira separadores de milhar
		$arrayNum[0] = str_replace($this->separadorMilhar, '', $arrayNum[0]);
		// Coloca ponto para verificação do is_numeric
		$num = implode('.', $arrayNum); 
		
		if (is_numeric($num)) {
			$this->numero = $this->geraString($num);
		}
	} 
	
	/**
	 * Retorna se o número é válido ou não
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
            throw new Zend_Locale_Exception('Configurações regionais não encontradas na tentativa de buscar os separadores numéricos da localização!');
            return false;
        } else {
			$separadores['separadorDecimal'] = $localeInfo['mon_decimal_point'];
			$separadores['separadorMilhar'] = $localeInfo['mon_thousands_sep'];
			return $separadores;
		}
    }
	
	
	/**
	 * Verifica se operação deve ou não ser executada. Se número não estiver setado, retorna false.
	 * 
	 * @name executaOperacao
	 * @access protected
	 * @return boolean
	 */	
	public function executaOperacao () {
		return (isset($this->numero))?true:false;
	}
	
	/**
	 * Formata string numérica para colocar em $numero, facilitando os cálculos
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
	 * Verifica se o parâmetro passado é um objeto da instância Axs_Util_Float ou se é um número comum,
	 * sendo que se for um objeto busca apenas o valor de seu $numero, caso contrário retorna o próprio
	 * valor passado como parâmetro.
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
	 * Seta a precisão a ser utilizada nos cálculos.
	 * 
	 * @name setPrecisao
	 * @param int 
	 * @access public 
	 * @return int
	 */
	public function setPrecisao ($precisao = 5)
	{
		if (!is_numeric($precisao) || strpos($precisao,'.') !== false || strpos($precisao,',') !== false || $precisao < 0) {
			throw new Zend_Exception("Parâmetro precisão precisa ser um número inteiro positivo");
		}

		// Configura o parâmetro precisao padrão para todas as chamadas subsequentes
		$this->precisao = $precisao;
	} 

	/**
	 * Retorna a precisão configurada como padrão
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
	 * Faz a soma do número com o passado por parâmetro. Retorna o próprio objeto com o total da soma em $numero.
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
	 * Faz a subtração do número com o passado por parâmetro. Retorna o próprio objeto com a diferença da subtração em $numero.
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
	 * Faz a multiplicação do número com o passado por parâmetro. Retorna o próprio objeto com o produto da multiplicação em $numero.
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
	 * Faz a divisão do número com o passado por parâmetro. Retorna o próprio objeto com o quociente da divisão em $numero.
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
	 * Faz o módulo do número de acordo com o valor passado por parâmetro. Retorna o próprio objeto com o resultado do módulo em $numero.
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
	 * Eleva o número ao valor passado por parâmetro. Retorna o próprio objeto com o resultado da exponenciação em $numero.
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
	 * Eleva o número ao valor passado por parâmetro levando em conta o módulo. Retorna o próprio objeto com o resultado em $numero.
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
	 * Eleva o número ao valor passado por parâmetro. Retorna o próprio objeto com o resultado da exponenciação em $numero.
	 * 
	 * @name raiz
	 * @param string|float|int|object $num Se não for informado nenhum valor é feita uma raiz quadrada por padrão.
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
	 * Compara se o número é maior que o número passado por parâmetro.
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
	 * Compara se o número é menor que o número passado por parâmetro.
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
	 * Compara se o número é igual ao número passado por parâmetro.
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
	 * Retorna o valor do número quando este foi instanciado.
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
	 * Retorna o número como Float, de acordo com so parâmetros passados.
	 * 
	 * @name getNumero
	 * @param boolean $arredondar Flag que determina se o número deve ou não ser arredondado ao truncar, de acordo com o número de casas
 	 * @param int $casasDecimais Número de casas decimais do número. Se não setado pega de acordo com a precisão.
	 * @param string $locale Locale padrão para a máscara utilizada, utilizando ponto (.) como separador decimal
	 * @access public 
	 * @return float|boolean
	 */
	public function getFloat ($arredondar = false, $casasDecimais = null, $locale = 'pt_BR')
	{
		if ($this->executaOperacao()) {
			// Se não estiver setado casas decimais pega de acordo com a precisão
			if (!isset($casasDecimais)) {
				$casasDecimais = $this->precisao;
			} 
			// Arredonda o número caso o parâmetro $arrendondar seja true, de acordo com as casas decimais desejadas
			// se não arredondar atribui a $num, substituindo ponto por vírgula
			($arredondar)?$num=round($this->numero, $casasDecimais):$num=str_replace('.', ',', $this->numero);
			
			// Se $num não for float ou se o locale for diferente de 'de_AT', um novo locale precisa ser informado e o float
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
	 * Método mágico que retorna a string formatada do número quando objeto usado em contexto de string
	 * 
	 * @return String
	 */
	public function __toString() {
		return Axs_Util_Float::formataNumero($this->numero);
	}	

	/**
	 * Retorna o número como Float, de acordo com so parâmetros passados.
	 * 
	 * @name formataNumero
	 * @param float|int|string|object Número a ser formatado 
	 * @param boolean $arredondar Flag que determina se o número deve ou não ser arredondado ao truncar, de acordo com o número de casas
	 * @param int $casasDecimais Número de casas decimais do número
	 * @param string $separadorDecimal String que determina o separador decimal do número 
	 * @access public
	 * @return string
	 */		
	public static function formataNumero ($num, $casasDecimais = 2, $arredondar = false, $separadorDecimal = null, $separadorMilhar = null) {
		
		if (empty($num)) {
			$num = 0;
		}	
		// Se não tiver setado separador decimal nem milhar, busca do locale
		if (!isset($separadorMilhar) || !isset($separadorDecimal)) {
			$arraySeparadores = Axs_Util_Float::buscaSeparadores();
			if (!isset($separadorDecimal)) {
				$separadorDecimal = $arraySeparadores['separadorDecimal']; 
			}
			if (!isset($separadorMilhar)) {
				$separadorMilhar = $arraySeparadores['separadorMilhar']; 
			}
		}
		
		// Verifica se parâmetro passado é instância da classe
		if (!($num instanceOf Axs_Util_Float)) {
			$num = new Axs_Util_Float($num, $casasDecimais);
		}
		// Pega o número passado do objeto
		$num = $num->getNumero();
				
		// Apenas executa o resto das rotinas se valor passado é numérico 
		if (is_numeric($num)) {
			// Se não for para arredondar, formata "manualmente"
			if ($arredondar == false) {
	
				$arrayNum = explode('.', $num);
				// Se números estiverem vazios, coloca zero
				if (empty($arrayNum[0])) {
					$arrayNum[0] = "0";
				}
				
				// Formata apenas parte inteira com separador milhar
				$arrayNum[0] = number_format($arrayNum[0], 0, '', $separadorMilhar);
				
				// Coloca zeros de acordo com número de casas decimais
				if (isset($arrayNum[1])) {
					$decimalLength = intval(strlen($arrayNum[1]));
				} else {
					// Inicia vars para não dar notice (undefined), caso vazio
					$decimalLength = 0;
					$arrayNum[1] = "";
				}
				if ($decimalLength < $casasDecimais) {
					for ($i=$decimalLength;$i<$casasDecimais;$i++) {
						$arrayNum[1] .= "0";
					}
					$parteDecimal = $arrayNum[1];
				} else {
					// Se não for 0, corta parte decimal de acordo com o número casas decimais
					$parteDecimal = substr($arrayNum[1], 0, $casasDecimais);
				}				
				return trim($arrayNum[0] . $separadorDecimal . $parteDecimal, $separadorDecimal);
			} else {
				// Caso contrário formata com number_format
				return number_format($num, $casasDecimais, $separadorDecimal, $separadorMilhar);
			}
		}
	}

} 

?>