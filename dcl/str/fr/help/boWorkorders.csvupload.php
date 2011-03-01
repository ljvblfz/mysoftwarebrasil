<?php
include("helpCommon.php");

helpHeader();
?>
<H3>Work Order CSV Upload</H3>
Les appels peuvent �tre upload�s gr�ce � un fichier CSV correctement format� (valeur s�par�es par des virgules).  Ce fichier est une option d'import/export commune pour la pluspart des logiciels traitant des donn�es de diff�rents formats.
<BR>
<BR>
<H4>Champs support�s Fields</H4>
Les champs obligatoires sont en gras:
<UL>
<LI><B>Produit</B>&nbsp;-&nbsp;Nom ou ID num�rique du produit.</LI>
<LI>client&nbsp;-&nbsp;Nom ou ID num�rique du client.</LI>
<LI><B>Date limite</B></LI>
<LI>D�but estim�</LI>
<LI>Fin estim�e</LI>
<LI><B>Heures estim�es</B></LI>
<LI><B>priorit�</B>&nbsp;-&nbsp;Nom ou ID num�rique de la priorit�.</LI>
<LI><B>s�v�rit�</B>&nbsp;-&nbsp;Nom ou ID num�rique de la s�v�rit�.</LI>
<LI>contact</LI>
<LI>telephone contact</LI>
<LI><B>r�sum�</B></LI>
<LI>notes</LI>
<LI><B>description</B></LI>
<LI><B>responsible</B>&nbsp;-&nbsp;Name or numeric ID of personnel responsible.</LI>
<LI>revision</LI>
</UL>
Note that your permissions may not permit you to specify some of the fields that are listed here.
<H4>File Format</H4>
The file must be a comma-delimited text file.  The first row should contain the field names as listed above.  Date and text fields must be enclosed in double quotes ( &quot; ).  Dates should be submitted in the same format expected by DCL.
<?php
helpFooter();
?>
