<!-- $Id: logout.tpl 12 2006-12-01 01:46:51Z mdean $ -->
<html>
	<head>
		<meta http-equiv="Set-Cookie" content="DCLINFO=">
		<script language="JavaScript">
			window.onload = function()
			{literal}{{/literal}
				if (parent.frames["menu"] && parent.frames["workspace"])
					parent.location.href="{$URL}";
				else
					location.href="{$URL}";
			{literal}}{/literal}
		</script>
	</head>
	<body>
	</body>
</html>