<html>
<!-- $Id: htmlPersonnelSelector.tpl 12 2006-12-01 01:46:51Z mdean $ -->
	<head>
		<frameset rows="75,*" border="0" frameborder="0">
			<frame name="topFrame" src="{$smarty.const.DCL_WWW_ROOT}main.php?menuAction=htmlPersonnelSelector.showControlFrame&multiple={$VAL_MULTIPLE}&filterID={$VAL_FILTERID|escape:"url"}" marginwidth="0" marginheight="0">
			<frame name="mainFrame" src="{$smarty.const.DCL_WWW_ROOT}main.php?menuAction=htmlPersonnelSelector.showBrowseFrame&multiple={$VAL_MULTIPLE}&filterID={$VAL_FILTERID|escape:"url"}" marginwidth="0" marginheight="0" scrolling="auto">
		</frameset>
	</head>
</html>