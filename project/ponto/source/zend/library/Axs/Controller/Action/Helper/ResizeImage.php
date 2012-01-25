<?
    

ini_set("memory_limit","64M");

require_once 'Zend/Controller/Action/Helper/Abstract.php';

/**
 * Helper de redimensionamento de imagem
 *
 * @name
 * @author Gustavo Alevato 09/04/2009 08:00:33
 * @package safciweb
 * @version $Id: ResizeImage.php,v 1.7 2009/01/22 17:14:08 awrsantos Exp $
 */
class Axs_Controller_Action_Helper_ResizeImage extends Zend_Controller_Action_Helper_Abstract{

    /**
    * Dados úteis para redimensionar imagem
    *
    * @name $dadosUteis
    * @access public
    * @var array
    * <code>
    * array(
    *            dadosUteis = array(
    *                            dimensao          => array com dados da imagem, //array
    *                            larguraFixa       => largura fixa, //float
    *                            alturaFixa        => altura fixa, //float
    *                            calc              => calculo de dimensao, //float
    *                            imgOrigem         => guarda a Imagem original, //array
    *                            type              => type do arquivo, //string
    *                            origemX           => altura da imagem original, //float
    *                            origemY           => largura da imagem original, //float
    *                            imgFinal          => imagem final ja redimensionada, //array
    *                        )
    * </code>
    */
    public $dadosUteis;

    /**
    * Método principal do Helper de RedimensionaImg, recebe as configurações da imagem.
    *
    * @name RedimensionaImg
    * @param array $dados
    * <code>
    * array(
    *            dados => array(
    *                              arquivo          => arquivo_imagem //string
    *                              valorFixo        => altura ou largura fixa // float
    *                              tipo             => at (pega a maior dimensao da imagem e transforma em $valor_fixo, calcula a outra dimensão proporcional
    *                                    			    l (transforma a largura em $valor_fixo)
    *                                    			    a (transforma a altura em $valor_fixo)
    *                              valorFixo2       => Quando tiver dimensões fixas ele preencherá o restante da imagem usando branco.
	*	                                     		   Obrigatoriamente o segundo parametro será altura
    *                           )
    *       )
    * </code>
    */

    public function resize($dados){

        $imagem = $dados['arquivo']['tmp_name'];
        $sizeImgOrigem = getimagesize($imagem);
        $saida = "/tmp/temp.jpg";
        $dadosUteis = array(
                                "dimensao"          => $sizeImgOrigem, //float
                                "larguraFixa"       => null, //float
                                "alturaFixa"        => null, //float
                                "calc"              => null, //float
                                "imgOrigem"         => null, //array
                                "type"              => null, //string
                                "origemX"           => null, //float
                                "origemY"           => null, //float
                                "imgFinal"          => null, //array
                            );


        if($dados['tipo']=="at" || $dados['tipo']==""){
		  if($dadosUteis['dimensao'][0]<$dados['valorFixo']){
		  	$dadosUteis['larguraFixa']      = $dadosUteis['dimensao'][0];
			$dadosUteis['alturaFixa']       = $dadosUteis['dimensao'][1];
			$dados['valorFixo']             = $dadosUteis['dimensao'][0];
			$dados['valorFixo2']            = $dadosUteis['dimensao'][1];
		  }else{
			if($dadosUteis['dimensao'][0]>$dadosUteis['dimensao'][1]){
                $dados['tipo'] = "l";
            }
			else{
                $dados['tipo'] = "a";
            }
		  }
		}

		if($dados['tipo']=="tb"){
		  	$dadosUteis['larguraFixa']      = $dados['valorFixo'];
			$dadosUteis['alturaFixa']       = $dados['valorFixo2'];
		}

		if($dados['tipo']=="l"){
			$dadosUteis['calc']             = $dados['valorFixo']*100/$dadosUteis['dimensao'][0];
			$dadosUteis['larguraFixa']      = $dados['valorFixo'];
            $dadosUteis['alturaFixa']       = round($dadosUteis['dimensao'][1]*$dadosUteis['calc']/100);
		}
		if($dados['tipo']=="a"){
			$dadosUteis['calc']             = $dados['valorFixo']*100/$dadosUteis['dimensao'][1];
			$dadosUteis['larguraFixa']      = round($dadosUteis['dimensao'][0]*$dadosUteis['calc']/100);
			$dadosUteis['alturaFixa']       = $dados['valorFixo'];

		}

		//Verifica o tipo de arquivo,
        //lê a imagem de origem e monta um resource
		if($dados['arquivo']['type']=='image/gif'){ #gif
	        $dadosUteis['imgOrigem']  = imagecreatefromgif($imagem);
		}elseif($dados['arquivo']['type']=='image/png'){ #png
			$dadosUteis['imgOrigem']  = imagecreatefrompng($imagem);
		}elseif($dados['arquivo']['type']=='image/bmp'){ #bmp
			$dadosUteis['imgOrigem']  = imagecreatefrombmp($imagem);
		}else{#jpg ou jpeg
		    $dadosUteis['imgOrigem']  = imagecreatefromjpeg($imagem);
		}

        //lê as dimensões da imagem original
        $dadosUteis['origemX']       = $dadosUteis['dimensao'][0];
        $dadosUteis['origemY']       = $dadosUteis['dimensao'][1];


        //cria uma imagem vazia com as novas dimensões
		if($dados['arquivo']['type']=='image/gif'){
			$dadosUteis['imgFinal'] = ImageCreate($dadosUteis['larguraFixa'],$dadosUteis['alturaFixa']);
		}else{
			$dadosUteis['imgFinal'] = ImageCreateTrueColor($dadosUteis['larguraFixa'],$dadosUteis['alturaFixa']);
		}

        // copia a imagem original redimensionada para dentro da imagem final
        ImageCopyResampled($dadosUteis['imgFinal'], $dadosUteis['imgOrigem'], 0, 0, 0, 0, $dadosUteis['larguraFixa']+1, $dadosUteis['alturaFixa']+1, $dadosUteis['origemX'] , $dadosUteis['origemY']);

        // Preencher com branco o espaço restante
		if($dados['valorFixo']!="" && $dados['valorFixo2']!=""){

			if($dados['arquivo']['type']=='image/gif'){ #jpg e jpeg
				$dadosUteis['imgOrigem'] = imagecreatefromgif($imagem);
				$fundo = ImageCreate($valor_fixo,$valor_fixo2);
			}else{
				$dadosUteis['imgOrigem'] = imagecreatefromjpeg($imagem);
				$fundo = ImageCreateTrueColor($dados['valorFixo'],$dados['valorFixo2']);
			}

			$branco = @imagecolorallocate($fundo, 255, 255,255);
			imagefill($fundo, 0, 0, $branco);

			$dadosUteis['origemX'] = ImagesX($fundo);
			$dadosUteis['origemY'] = ImagesY($fundo);

 			# Posição da Miniatura dentro das Dimensões Fixas
			$pos_x=0;	$ini_ret_x=0;
			$pos_y=0;	$ini_ret_y=0;
			if($tipo=="a"){	  # 135 - 110 /2
				$pos_x=round(($dados['valorFixo']-$dadosUteis['larguraFixa'])/2,0);
				$ini_ret_x=$dadosUteis['larguraFixa']+$pos_x;
			}else{
				$pos_y=round(($dados['valorFixo2']-$dadosUteis['alturaFixa'])/2,0);
				$ini_ret_y=$dadosUteis['alturaFixa']+$pos_y;
			}

			# Cola Miniatura dentro das Dimensões Fixas
			#imagecopyresampled(
			ImageCopyResampled($fundo, $dadosUteis['imgFinal'], $pos_x, $pos_y, 0, 0, $dados['valorFixo'], $dados['valorFixo2'], $dadosUteis['origemX'], $dadosUteis['origemY']);

			imagefilledrectangle($fundo,$ini_ret_x,$ini_ret_y,$dados['valorFixo'], $dados['valorFixo2'],$branco);

			$dadosUteis['imgFinal'] = $fundo;


		}

		// salva o arquivo
		if($dados['arquivo']['type']=='image/gif'){ #gif
			$gerou=ImageGIF($dadosUteis['imgFinal'], $saida, 70);
		}elseif($dados['arquivo']['type']=='image/png'){ #png
			$gerou=ImagePNG($dadosUteis['imgFinal'], $saida, 7);
		}else{ #jpg e jpeg
			$gerou=ImageJPEG($dadosUteis['imgFinal'], $saida, 70);
		}

		imagegammacorrect($dadosUteis['imgFinal'], 100.0, 100);

        $img = base64_encode(file_get_contents($saida));
        // libera a memória alocada para as duas imagens
        ImageDestroy($dadosUteis['imgOrigem']);
        ImageDestroy($dadosUteis['imgFinal']);

        return $img;
    }

    
    public function direct($name, $options = null)
    {
        $this->controller = $this->getActionController();
        $this->action = $this->getRequest();

        return $this;
    }
    
    public function imagecreatefrombmp($p_sFile)
    {
        //    Load the image into a string
        $file    =    fopen($p_sFile,"rb");
        $read    =    fread($file,10);
        while(!feof($file)&&($read<>""))
            $read    .=    fread($file,1024);
       
        $temp    =    unpack("H*",$read);
        $hex    =    $temp[1];
        $header    =    substr($hex,0,108);
       
        //    Process the header
        //    Structure: http://www.fastgraph.com/help/bmp_header_format.html
        if (substr($header,0,4)=="424d")
        {
            //    Cut it in parts of 2 bytes
            $header_parts    =    str_split($header,2);
           
            //    Get the width        4 bytes
            $width            =    hexdec($header_parts[19].$header_parts[18]);
           
            //    Get the height        4 bytes
            $height            =    hexdec($header_parts[23].$header_parts[22]);
           
            //    Unset the header params
            unset($header_parts);
        }
       
        //    Define starting X and Y
        $x                =    0;
        $y                =    1;
       
        //    Create newimage
        $image            =    imagecreatetruecolor($width,$height);
       
        //    Grab the body from the image
        $body            =    substr($hex,108);

        //    Calculate if padding at the end-line is needed
        //    Divided by two to keep overview.
        //    1 byte = 2 HEX-chars
        $body_size        =    (strlen($body)/2);
        $header_size    =    ($width*$height);

        //    Use end-line padding? Only when needed
        $usePadding        =    ($body_size>($header_size*3)+4);
       
        //    Using a for-loop with index-calculation instaid of str_split to avoid large memory consumption
        //    Calculate the next DWORD-position in the body
        for ($i=0;$i<$body_size;$i+=3)
        {
            //    Calculate line-ending and padding
            if ($x>=$width)
            {
                //    If padding needed, ignore image-padding
                //    Shift i to the ending of the current 32-bit-block
                if ($usePadding)
                    $i    +=    $width%4;
               
                //    Reset horizontal position
                $x    =    0;
               
                //    Raise the height-position (bottom-up)
                $y++;
               
                //    Reached the image-height? Break the for-loop
                if ($y>$height)
                    break;
            }
           
            //    Calculation of the RGB-pixel (defined as BGR in image-data)
            //    Define $i_pos as absolute position in the body
            $i_pos    =    $i*2;
            $r        =    hexdec($body[$i_pos+4].$body[$i_pos+5]);
            $g        =    hexdec($body[$i_pos+2].$body[$i_pos+3]);
            $b        =    hexdec($body[$i_pos].$body[$i_pos+1]);
           
            //    Calculate and draw the pixel
            $color    =    imagecolorallocate($image,$r,$g,$b);
            imagesetpixel($image,$x,$height-$y,$color);
           
            //    Raise the horizontal position
            $x++;
        }
       
        //    Unset the body / free the memory
        unset($body);
       
        //    Return image-object
        return $image;
    } 
    
}