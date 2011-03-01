<?php /* Smarty version 2.6.2, created on 2011-03-01 11:14:35
         compiled from logout.tpl */ ?>
<!-- $Id: logout.tpl 12 2006-12-01 01:46:51Z mdean $ -->
<html>
	<head>
		<meta http-equiv="Set-Cookie" content="DCLINFO=">
		<script language="JavaScript">
			window.onload = function()
			<?php echo '{'; ?>

				if (parent.frames["menu"] && parent.frames["workspace"])
					parent.location.href="<?php echo $this->_tpl_vars['URL']; ?>
";
				else
					location.href="<?php echo $this->_tpl_vars['URL']; ?>
";
			<?php echo '}'; ?>

		</script>
	</head>
	<body>
	</body>
</html>