<?php


Zend_Loader :: loadClass('Zend_Locale_Math');
Zend_Loader :: loadClass('Zend_Locale_Math_PhpMath');
Zend_Loader :: loadClass('Zend_Locale');
Zend_Loader :: loadClass('Zend_Locale_Exception');
Zend_Loader :: loadClass('Zend_Locale_Format');

class Sabv_Util_Float{

     protected $precisao;

     protected $numero;

     protected $numeroOriginal;


     protected $separadorDecimal;


     protected $separadorMilhar;


     public function __construct ($num = 0, $precisao = 5, $throwException = false)
    {
         $this -> numeroOriginal = $num;
         $this -> setPrecisao($precisao);
         $num = trim($num);
         if (empty($num)){
             $num = "0";
             }

         $sep = Sabv_Util_Float :: buscaSeparadores();
         $this -> separadorDecimal = $sep['separadorDecimal'];
         $this -> separadorMilhar = $sep['separadorMilhar'];

         if (strpos($num, $this -> separadorDecimal) === 0){
             $num = '0' . $num;
             }

         $posSeparadorMilhar = strpos($num, $this -> separadorMilhar);
         $posSeparadorDecimal = strpos($num, $this -> separadorDecimal);
         if ($posSeparadorDecimal !== false && $posSeparadorMilhar !== false &&
             $posSeparadorDecimal < $posSeparadorMilhar){
             if ($throwException){
                 throw new Zend_Locale_Exception('Formato inválido: separador decimal não pode vir antes do separador de milhar');
                 }else{
                 $num = null;
                 }
             }

         $arrayNum = explode($this -> separadorDecimal, $num);
         if (count($arrayNum) > 2){
             if ($throwException){
                 throw new Zend_Locale_Exception('Formato inválido: número passado possui mais de um separador decimal');
                 }else{
                 $arrayNum = null;
                 }
             }

         if (strpos($num, $this -> separadorMilhar) !== false){
             $parteInteira = explode($this -> separadorMilhar, $arrayNum[0]);
             foreach($parteInteira as $chave => $valor){
                 $strlenValor = strlen($valor);
                 if ($strlenValor > 3 || ($strlenValor < 2 && $chave != 0)){
                     if ($throwException){
                         throw new Zend_Locale_Exception('Formato inválido');
                         }else{
                         $arrayNum = null;
                         break;
                         }
                     }
                 }
             }
         $arrayNum[0] = str_replace($this -> separadorMilhar, '', $arrayNum[0]);
         $num = implode('.', $arrayNum);

         if (is_numeric($num)){
             $this -> numero = $this -> geraString($num);
             }
         }


     public function eNumero(){
         return (isset($this -> numero))?true:false;
         }


     public static function buscaSeparadores()
    {
         $localeInfo = localeconv();
         if (empty($localeInfo['mon_decimal_point'])){
             throw new Zend_Locale_Exception('Configurações regionais não encontradas na tentativa de buscar os separadores numéricos da localização!');
             return false;
             }else{
             $separadores['separadorDecimal'] = $localeInfo['mon_decimal_point'];
             $separadores['separadorMilhar'] = $localeInfo['mon_thousands_sep'];
             return $separadores;
             }
         }



     public function executaOperacao (){
         return (isset($this -> numero))?true:false;
         }


     protected function geraString ($num)
    {
         $num = str_replace('.', ',', $num);
         $num = Zend_Locale_Format :: getNumber($num);
         return strval($num);
         }


     protected function getParam ($num)
    {
         if (!$num instanceOf Sabv_Util_Float){
             $num = new Sabv_Util_Float($num);
             }
         return $num -> getNumero();
         }


     public function setPrecisao ($precisao = 5)
    {
         if (!is_numeric($precisao) || strpos($precisao, '.') !== false || strpos($precisao, ',') !== false || $precisao < 0){
             throw new Zend_Exception("Parâmetro precisão precisa ser um número inteiro positivo");
             }

         $this -> precisao = $precisao;
         }


     public function getPrecisao ()
    {
         return $this -> precisao;
         }


     public function soma ($num)
    {
         if ($this -> executaOperacao()){
             $this -> numero = Zend_Locale_Math_PhpMath :: Add($this -> numero, $this -> getParam($num), $this -> precisao);
             return $this;
             }else{
             return false;
             }
         }


     public function subtrai ($num)
    {
         if ($this -> executaOperacao()){
             $this -> numero = Zend_Locale_Math_PhpMath :: Sub($this -> numero, $this -> getParam($num), $this -> precisao);
             return $this;
             }else{
             return false;
             }
         }


     public function multiplica ($num)
    {
         if ($this -> executaOperacao()){
             $this -> numero = Zend_Locale_Math_PhpMath :: Mul($this -> numero, $this -> getParam($num), $this -> precisao);
             return $this;
             }else{
             return false;
             }
         }


     public function divide ($num)
    {
         if ($this -> executaOperacao()){
             $this -> numero = Zend_Locale_Math_PhpMath :: Div($this -> numero, $this -> getParam($num), $this -> precisao);
             return $this;
             }else{
             return false;
             }
         }


     public function modulo ($num)
    {
         if ($this -> executaOperacao()){
             $this -> numero = Zend_Locale_Math_PhpMath :: Mod($this -> numero, $this -> getParam($num), $this -> precisao);
             return $this;
             }else{
             return false;
             }
         }


     public function eleva ($num)
    {
         if ($this -> executaOperacao()){
             $this -> numero = Zend_Locale_Math_PhpMath :: Pow($this -> numero, $this -> getParam($num), $this -> precisao);
             return $this;
             }else{
             return false;
             }
         }


     public function elevaMod($num, $modulo)
    {
         if ($this -> executaOperacao()){
             $num = $this -> geraString($this -> getParam($num));
             $this -> numero = bcpowmod($this -> numero, $num, $modulo, $this -> precisao);
             return $this;
             }else{
             return false;
             }
         }


     public function raiz ($num = 2)
    {
         if ($this -> executaOperacao()){
             $this -> numero = Zend_Locale_Math_PhpMath :: Sqrt($this -> numero, $this -> getParam($num), $this -> precisao);
             return $this;
             }else{
             return false;
             }
         }

     public function eMaior ($num)
    {

         if ($this -> executaOperacao()){
             return (Zend_Locale_Math_PhpMath :: Comp($this -> numero, $this -> getParam($num), $this -> precisao) == 1);
             }else{
             return false;
             }
         }


     public function eMenor ($num)
    {
         if ($this -> executaOperacao()){
             return (Zend_Locale_Math_PhpMath :: Comp($this -> numero, $this -> getParam($num), $this -> precisao) == -1);
             }else{
             return false;
             }
         }


     public function eIgual($num)
    {
         if ($this -> executaOperacao()){
             return (Zend_Locale_Math_PhpMath :: Comp($this -> numero, $this -> getParam($num), $this -> precisao) == 0);
             }else{
             return false;
             }
         }


     public function getNumero()
    {
         return $this -> numero;
         }


     public function getNumeroOriginal()
    {
         return $this -> numeroOriginal;
         }


     public function getFloat ($arredondar = false, $casasDecimais = null, $locale = 'pt_BR')
    {
         if ($this -> executaOperacao()){
             if (!isset($casasDecimais)){
                 $casasDecimais = $this -> precisao;
                 }
             ($arredondar)?$num = round($this -> numero, $casasDecimais):$num = str_replace('.', ',', $this -> numero);

             if (!is_float($num) || $locale != 'pt_BR'){
                 $num = Zend_Locale_Format :: getFloat($num, array('precision' => $casasDecimais, 'locale' => $locale));
                 }
             return $num;
             }else{
             return false;
             }
         }


     public function __toString(){
         return Sabv_Util_Float :: formataNumero($this -> numero);
         }


     public static function formataNumero ($num, $casasDecimais = 2, $arredondar = false, $separadorDecimal = null, $separadorMilhar = null){

         if (empty($num)){
             $num = 0;
             }
         if (!isset($separadorMilhar) || !isset($separadorDecimal)){
             $arraySeparadores = Sabv_Util_Float :: buscaSeparadores();
             if (!isset($separadorDecimal)){
                 $separadorDecimal = $arraySeparadores['separadorDecimal'];
                 }
             if (!isset($separadorMilhar)){
                 $separadorMilhar = $arraySeparadores['separadorMilhar'];
                 }
             }

         if (!($num instanceOf Sabv_Util_Float)){
             $num = new Sabv_Util_Float($num, $casasDecimais);
             }
         $num = $num -> getNumero();

         if (is_numeric($num)){
             if ($arredondar == false){

                 $arrayNum = explode('.', $num);
                 if (empty($arrayNum[0])){
                     $arrayNum[0] = "0";
                     }

                 $arrayNum[0] = number_format($arrayNum[0], 0, '', $separadorMilhar);

                 if (isset($arrayNum[1])){
                     $decimalLength = intval(strlen($arrayNum[1]));
                     }else{
                     $decimalLength = 0;
                     $arrayNum[1] = "";
                     }
                 if ($decimalLength < $casasDecimais){
                     for ($i = $decimalLength;$i < $casasDecimais;$i++){
                         $arrayNum[1] .= "0";
                         }
                     $parteDecimal = $arrayNum[1];
                     }else{
                     $parteDecimal = substr($arrayNum[1], 0, $casasDecimais);
                     }
                 return trim($arrayNum[0] . $separadorDecimal . $parteDecimal, $separadorDecimal);
                 }else{
                 return number_format($num, $casasDecimais, $separadorDecimal, $separadorMilhar);
                 }
             }
         }

    }

?>