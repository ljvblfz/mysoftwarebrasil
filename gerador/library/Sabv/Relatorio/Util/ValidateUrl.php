<?php


class Sabv_Relatorio_Util_ValidateUrl{
     public static function validateUrlSyntax($urladdr, $options = "")
    {
         if (!ereg('^([sHSEFuPaIpfqr][+?-])*$', $options)){
             trigger_error("Options attribute malformed", E_USER_ERROR);
             }
         if (strpos($options, 's') === false) $aOptions['s'] = '?';
         else $aOptions['s'] = substr($options, strpos($options, 's') + 1, 1);
         if (strpos($options, 'H') === false) $aOptions['H'] = '?';
         else $aOptions['H'] = substr($options, strpos($options, 'H') + 1, 1);
         if (strpos($options, 'S') === false) $aOptions['S'] = '?';
         else $aOptions['S'] = substr($options, strpos($options, 'S') + 1, 1);
         if (strpos($options, 'E') === false) $aOptions['E'] = '-';
         else $aOptions['E'] = substr($options, strpos($options, 'E') + 1, 1);
         if (strpos($options, 'F') === false) $aOptions['F'] = '-';
         else $aOptions['F'] = substr($options, strpos($options, 'F') + 1, 1);
         if (strpos($options, 'u') === false) $aOptions['u'] = '?';
         else $aOptions['u'] = substr($options, strpos($options, 'u') + 1, 1);
         if (strpos($options, 'P') === false) $aOptions['P'] = '?';
         else $aOptions['P'] = substr($options, strpos($options, 'P') + 1, 1);
         if (strpos($options, 'a') === false) $aOptions['a'] = '+';
         else $aOptions['a'] = substr($options, strpos($options, 'a') + 1, 1);
         if (strpos($options, 'I') === false) $aOptions['I'] = '?';
         else $aOptions['I'] = substr($options, strpos($options, 'I') + 1, 1);
         if (strpos($options, 'p') === false) $aOptions['p'] = '?';
         else $aOptions['p'] = substr($options, strpos($options, 'p') + 1, 1);
         if (strpos($options, 'f') === false) $aOptions['f'] = '?';
         else $aOptions['f'] = substr($options, strpos($options, 'f') + 1, 1);
         if (strpos($options, 'q') === false) $aOptions['q'] = '?';
         else $aOptions['q'] = substr($options, strpos($options, 'q') + 1, 1);
         if (strpos($options, 'r') === false) $aOptions['r'] = '?';
         else $aOptions['r'] = substr($options, strpos($options, 'r') + 1, 1);
         foreach($aOptions as $key => $value){
             if ($value == '-'){
                 $aOptions[$key] = '{0}';
                 }
             if ($value == '+'){
                 $aOptions[$key] = '';
                 }
             }
         $alphanum = '[a-zA-Z0-9]'; // Alpha Numeric
         $unreserved = '[a-zA-Z0-9_.!~*' . '\'' . '()-]';
         $escaped = '(%[0-9a-fA-F]{2})'; // Escape sequence - In Hex - %6d would be a 'm'
         $reserved = '[;/?:@&=+$,]'; // Special characters in the URI
         $scheme = '(';
         if ($aOptions['H'] === ''){
             $scheme .= 'http://';
             }elseif ($aOptions['S'] === ''){
             $scheme .= 'https://';
             }elseif ($aOptions['E'] === ''){
             $scheme .= 'mailto:';
             }elseif ($aOptions['F'] === ''){
             $scheme .= 'ftp://';
             }else{
             if ($aOptions['H'] === '?'){
                 $scheme .= '|(http://)';
                 }
             if ($aOptions['S'] === '?'){
                 $scheme .= '|(https://)';
                 }
             if ($aOptions['E'] === '?'){
                 $scheme .= '|(mailto:)';
                 }
             if ($aOptions['F'] === '?'){
                 $scheme .= '|(ftp://)';
                 }
             $scheme = str_replace('(|', '(', $scheme); // fix first pipe
             }
         $scheme .= ')' . $aOptions['s'];
         $userinfo = '((' . $unreserved . '|' . $escaped . '|[;&=+$,]' . ')+(:(' . $unreserved . '|' . $escaped . '|[;:&=+$,]' . ')+)' . $aOptions['P'] . '@)' . $aOptions['u'];
         $ipaddress = '((((2(([0-4][0-9])|(5[0-5])))|([01]?[0-9]?[0-9]))\.){3}((2(([0-4][0-9])|(5[0-5])))|([01]?[0-9]?[0-9])))';
         $domain_tertiary = '(' . $alphanum . '(([a-zA-Z0-9-]{0,62})' . $alphanum . ')?\.)*';
         $domain_secondary = '(' . $alphanum . '(([a-zA-Z0-9-]{0,62})' . $alphanum . ')?\.)';


         $domain_toplevel = '(aero|biz|com|coop|edu|gov|info|int|mil|museum|name|net|org|pro|ac|ad|ae|af|ag|ai|al|am|an|ao|aq|ar|as|at|au|aw|az|ax|ba|bb|bd|be|bf|bg|bh|bi|bj|bm|bn|bo|br|bs|bt|bv|bw|by|bz|ca|cc|cd|cf|cg|ch|ci|ck|cl|cm|cn|co|cr|cs|cu|cv|cx|cy|cz|de|dj|dk|dm|do|dz|ec|ee|eg|eh|er|es|et|fi|fj|fk|fm|fo|fr|ga|gb|gd|ge|gf|gg|gh|gi|gl|gm|gn|gp|gq|gr|gs|gt|gu|gw|gy|hk|hm|hn|hr|ht|hu|id|ie|il|im|in|io|iq|ir|is|it|je|jm|jo|jp|ke|kg|kh|ki|km|kn|kp|kr|kw|ky|kz|la|lb|lc|li|lk|lr|ls|lt|lu|lv|ly|ma|mc|md|mg|mh|mk|ml|mm|mn|mo|mp|mq|mr|ms|mt|mu|mv|mw|mx|my|mz|na|nc|ne|nf|ng|ni|nl|no|np|nr|nu|nz|om|pa|pe|pf|pg|ph|pk|pl|pm|pn|pr|ps|pt|pw|py|qa|re|ro|ru|rw|sa|sb|sc|sd|se|sg|sh|si|sj|sk|sl|sm|sn|so|sr|st|sv|sy|sz|tc|td|tf|tg|th|tj|tk|tl|tm|tn|to|tp|tr|tt|tv|tw|tz|ua|ug|uk|um|us|uy|uz|va|vc|ve|vg|vi|vn|vu|wf|ws|ye|yt|yu|za|zm|zw)';
         if ($aOptions['I'] === '{0}'){ // IP Address Not Allowed
             $address = '(' . $domain_tertiary . $domain_secondary . $domain_toplevel . ')';
             }elseif ($aOptions['I'] === ''){ // IP Address Required
             $address = '(' . $ipaddress . ')';
             }else{ // IP Address Optional
             $address = '((' . $ipaddress . ')|(' . $domain_tertiary . $domain_secondary . $domain_toplevel . '))';
             }
         $address = $address . $aOptions['a'];
         $port_number = '(:(([0-5]?[0-9]{1,4})|(6[0-4][0-9]{3})|(65[0-4][0-9]{2})|(655[0-2][0-9])|(6553[0-5])))' . $aOptions['p'];
         $path = '(/((;)?(' . $unreserved . '|' . $escaped . '|' . '[:@&=+$,]' . ')+(/)?)*)' . $aOptions['f'];
         $querystring = '(\?(' . $reserved . '|' . $unreserved . '|' . $escaped . ')*)' . $aOptions['q'];
         $fragment = '(#(' . $reserved . '|' . $unreserved . '|' . $escaped . ')*)' . $aOptions['r'];
         $regexp = '^' . $scheme . $userinfo . $address . $port_number . $path . $querystring . $fragment . '$';
         if (eregi($regexp, $urladdr)){
             return true; // The domain passed
             }else{
             return false; // The domain didn't pass the expression
             }
         } // END Function validateUrlSyntax()
    }

?>