<html>
<!-- $Id: htmlProductSelector.tpl 65 2007-02-27 07:15:12Z mdean $ -->
	<head>
		<title>Select Product</title>
		<frameset rows="85,*" border="0" frameborder="0">
			<frame name="topFrame" src="{$smarty.const.DCL_WWW_ROOT}main.php?menuAction=htmlProductSelector.showControlFrame&multiple={$VAL_MULTIPLE}&filterID={$VAL_FILTERID|escape:"url"}&filterActive={$VAL_FILTERACTIVE}" marginwidth="0" marginheight="0">
			<frame name="mainFrame" src="{$smarty.const.DCL_WWW_ROOT}main.php?menuAction=htmlProductSelector.showBrowseFrame&multiple={$VAL_MULTIPLE}&filterID={$VAL_FILTERID|escape:"url"}&filterActive={$VAL_FILTERACTIVE}" marginwidth="0" marginheight="0" scrolling="auto">
		</frameset>
	</head>
</html>