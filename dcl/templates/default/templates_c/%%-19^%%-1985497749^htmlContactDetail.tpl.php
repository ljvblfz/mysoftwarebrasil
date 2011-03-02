<?php /* Smarty version 2.6.2, created on 2011-03-01 22:04:51
         compiled from htmlContactDetail.tpl */ ?>
<?php require_once(SMARTY_DIR . 'core' . DIRECTORY_SEPARATOR . 'core.load_plugins.php');
smarty_core_load_plugins(array('plugins' => array(array('function', 'cycle', 'htmlContactDetail.tpl', 74, false),array('function', 'mailto', 'htmlContactDetail.tpl', 186, false),array('modifier', 'escape', 'htmlContactDetail.tpl', 134, false),)), $this); ?>
<!-- $Id: htmlContactDetail.tpl 120 2009-03-29 23:03:19Z mdean $ -->
<script language="JavaScript">
<?php echo '
	function deleteAddress(id)
	{
		if (confirm("Are you sure you want to delete this address?"))
'; ?>

			location.href = "<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContactAddress.submitDelete&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
&contact_addr_id=" + id;
<?php echo '
	}
	function deleteEmail(id)
	{
		if (confirm("Are you sure you want to delete this e-mail?"))
'; ?>

			location.href = "<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContactEmail.submitDelete&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
&contact_email_id=" + id;
<?php echo '
	}
	function deleteLicense(id)
	{
		if (confirm("Are you sure you want to delete this product license?"))
'; ?>

			location.href = "<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContactLicenses.submitDelete&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
&contact_license_id=" + id;
<?php echo '
	}
	function deletePhone(id)
	{
		if (confirm("Are you sure you want to delete this phone number?"))
'; ?>

			location.href = "<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContactPhone.submitDelete&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
&contact_phone_id=" + id;
<?php echo '
	}
	function deleteUrl(id)
	{
		if (confirm("Are you sure you want to delete this URL?"))
'; ?>

			location.href = "<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContactUrl.submitDelete&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
&contact_url_id=" + id;
<?php echo '
	}
'; ?>

</script>
<table width="100%" class="dcl_results">
	<caption>Contact [<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
] <?php echo $this->_reg_objects['Contact'][0]->first_name;?>
 <?php echo $this->_reg_objects['Contact'][0]->last_name;?>
</caption>
	<thead>
		<tr class="toolbar">
			<th>
				<ul>
					<li class="first"><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContactBrowse.show&filterActive=Y">Browse</a></li>
					<li><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContact.viewWorkOrders&id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
">Work Orders</a></li>
					<li><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContact.viewTickets&id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
">Tickets</a></li>
					<?php if ($this->_tpl_vars['PERM_MODIFY']): ?><li><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContact.merge&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
">Merge</a></li><?php endif; ?>
					<?php if ($this->_tpl_vars['PERM_MODIFY']): ?><li><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContactForm.modify&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
"><?php echo @constant('STR_CMMN_EDIT'); ?>
</a></li><?php endif; ?>
					<?php if ($this->_tpl_vars['PERM_DELETE']): ?><li><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContactForm.delete&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
"><?php echo @constant('STR_CMMN_DELETE'); ?>
</a></li><?php endif; ?>
				</ul>
			</th>
		</tr>
	</thead>
	<tbody>
		<tr><td class="string">
<?php if (isset($this->_sections['typeitem'])) unset($this->_sections['typeitem']);
$this->_sections['typeitem']['name'] = 'typeitem';
$this->_sections['typeitem']['loop'] = is_array($_loop=$this->_tpl_vars['ContactType']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);
$this->_sections['typeitem']['show'] = true;
$this->_sections['typeitem']['max'] = $this->_sections['typeitem']['loop'];
$this->_sections['typeitem']['step'] = 1;
$this->_sections['typeitem']['start'] = $this->_sections['typeitem']['step'] > 0 ? 0 : $this->_sections['typeitem']['loop']-1;
if ($this->_sections['typeitem']['show']) {
    $this->_sections['typeitem']['total'] = $this->_sections['typeitem']['loop'];
    if ($this->_sections['typeitem']['total'] == 0)
        $this->_sections['typeitem']['show'] = false;
} else
    $this->_sections['typeitem']['total'] = 0;
if ($this->_sections['typeitem']['show']):

            for ($this->_sections['typeitem']['index'] = $this->_sections['typeitem']['start'], $this->_sections['typeitem']['iteration'] = 1;
                 $this->_sections['typeitem']['iteration'] <= $this->_sections['typeitem']['total'];
                 $this->_sections['typeitem']['index'] += $this->_sections['typeitem']['step'], $this->_sections['typeitem']['iteration']++):
$this->_sections['typeitem']['rownum'] = $this->_sections['typeitem']['iteration'];
$this->_sections['typeitem']['index_prev'] = $this->_sections['typeitem']['index'] - $this->_sections['typeitem']['step'];
$this->_sections['typeitem']['index_next'] = $this->_sections['typeitem']['index'] + $this->_sections['typeitem']['step'];
$this->_sections['typeitem']['first']      = ($this->_sections['typeitem']['iteration'] == 1);
$this->_sections['typeitem']['last']       = ($this->_sections['typeitem']['iteration'] == $this->_sections['typeitem']['total']);
 echo $this->_tpl_vars['ContactType'][$this->_sections['typeitem']['index']]['contact_type_name'];  if (! $this->_sections['typeitem']['last']): ?>,&nbsp;<?php endif;  endfor; else: ?>
No contact types!
<?php endif; ?>
		</td></tr>
	</tbody>
</table>
<table width="100%" class="dcl_results">
	<caption class="spacer"><?php echo @constant('STR_CM_ADDR'); ?>
Addresses</caption>
	<thead>
		<tr class="toolbar"><th colspan="3"><ul><li class="first"><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContactAddress.add&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
" class="adark"><?php echo @constant('STR_CMMN_NEW'); ?>
</a></li></ul></th></tr>
	</thead>
	<tbody>
		<?php if (isset($this->_sections['address'])) unset($this->_sections['address']);
$this->_sections['address']['name'] = 'address';
$this->_sections['address']['loop'] = is_array($_loop=$this->_tpl_vars['ContactAddress']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);
$this->_sections['address']['show'] = true;
$this->_sections['address']['max'] = $this->_sections['address']['loop'];
$this->_sections['address']['step'] = 1;
$this->_sections['address']['start'] = $this->_sections['address']['step'] > 0 ? 0 : $this->_sections['address']['loop']-1;
if ($this->_sections['address']['show']) {
    $this->_sections['address']['total'] = $this->_sections['address']['loop'];
    if ($this->_sections['address']['total'] == 0)
        $this->_sections['address']['show'] = false;
} else
    $this->_sections['address']['total'] = 0;
if ($this->_sections['address']['show']):

            for ($this->_sections['address']['index'] = $this->_sections['address']['start'], $this->_sections['address']['iteration'] = 1;
                 $this->_sections['address']['iteration'] <= $this->_sections['address']['total'];
                 $this->_sections['address']['index'] += $this->_sections['address']['step'], $this->_sections['address']['iteration']++):
$this->_sections['address']['rownum'] = $this->_sections['address']['iteration'];
$this->_sections['address']['index_prev'] = $this->_sections['address']['index'] - $this->_sections['address']['step'];
$this->_sections['address']['index_next'] = $this->_sections['address']['index'] + $this->_sections['address']['step'];
$this->_sections['address']['first']      = ($this->_sections['address']['iteration'] == 1);
$this->_sections['address']['last']       = ($this->_sections['address']['iteration'] == $this->_sections['address']['total']);
?>
		<?php echo smarty_function_cycle(array('values' => "odd,even",'assign' => 'rowClass'), $this);?>

		<tr class="<?php echo $this->_tpl_vars['rowClass']; ?>
">
		<td class="rowheader"><?php echo $this->_tpl_vars['ContactAddress'][$this->_sections['address']['index']]['addr_type_name'];  if ($this->_tpl_vars['ContactAddress'][$this->_sections['address']['index']]['preferred'] == 'Y'): ?><span style="color:#a00000;">*</span><?php endif; ?></td>
		<td>
		<?php echo $this->_tpl_vars['ContactAddress'][$this->_sections['address']['index']]['add1']; ?>
<br />
		<?php if ($this->_tpl_vars['ContactAddress'][$this->_sections['address']['index']]['add2'] != ""): ?>
			<?php echo $this->_tpl_vars['ContactAddress'][$this->_sections['address']['index']]['add2']; ?>
<br />
		<?php endif; ?>
		<?php echo $this->_tpl_vars['ContactAddress'][$this->_sections['address']['index']]['city']; ?>
, <?php echo $this->_tpl_vars['ContactAddress'][$this->_sections['address']['index']]['state']; ?>
   <?php echo $this->_tpl_vars['ContactAddress'][$this->_sections['address']['index']]['zip']; ?>

		<?php if ($this->_tpl_vars['ContactAddress'][$this->_sections['address']['index']]['country'] != ""): ?>
			<br /><?php echo $this->_tpl_vars['ContactAddress'][$this->_sections['address']['index']]['country']; ?>

		<?php endif; ?>
		</td>
<td class="options"><?php if ($this->_tpl_vars['PERM_MODIFY']): ?><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>?menuAction=htmlContactAddress.modify&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>&contact_addr_id=<?php echo $this->_tpl_vars['ContactAddress'][$this->_sections['address']['index']]['contact_addr_id']; ?>"><?php echo @constant('STR_CMMN_EDIT'); ?></a>&nbsp;|&nbsp;<a href="javascript:;" onclick="deleteAddress(<?php echo $this->_tpl_vars['ContactAddress'][$this->_sections['address']['index']]['contact_addr_id']; ?>);"><?php echo @constant('STR_CMMN_DELETE'); ?></a><?php endif; ?></td></tr>
		<?php endfor; endif; ?>
	</tbody>
</table>
<table width="100%" class="dcl_results">
	<caption class="spacer"><?php echo @constant('STR_CM_PHONENUMBERS'); ?>
Phone Numbers</caption>
	<thead>
		<tr class="toolbar"><th colspan="3"><ul><li class="first"><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContactPhone.add&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
" class="adark"><?php echo @constant('STR_CMMN_NEW'); ?>
</a></li></ul></th></tr>
	</thead>
	<tbody>
<?php if (isset($this->_sections['phone'])) unset($this->_sections['phone']);
$this->_sections['phone']['name'] = 'phone';
$this->_sections['phone']['loop'] = is_array($_loop=$this->_tpl_vars['ContactPhone']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);
$this->_sections['phone']['show'] = true;
$this->_sections['phone']['max'] = $this->_sections['phone']['loop'];
$this->_sections['phone']['step'] = 1;
$this->_sections['phone']['start'] = $this->_sections['phone']['step'] > 0 ? 0 : $this->_sections['phone']['loop']-1;
if ($this->_sections['phone']['show']) {
    $this->_sections['phone']['total'] = $this->_sections['phone']['loop'];
    if ($this->_sections['phone']['total'] == 0)
        $this->_sections['phone']['show'] = false;
} else
    $this->_sections['phone']['total'] = 0;
if ($this->_sections['phone']['show']):

            for ($this->_sections['phone']['index'] = $this->_sections['phone']['start'], $this->_sections['phone']['iteration'] = 1;
                 $this->_sections['phone']['iteration'] <= $this->_sections['phone']['total'];
                 $this->_sections['phone']['index'] += $this->_sections['phone']['step'], $this->_sections['phone']['iteration']++):
$this->_sections['phone']['rownum'] = $this->_sections['phone']['iteration'];
$this->_sections['phone']['index_prev'] = $this->_sections['phone']['index'] - $this->_sections['phone']['step'];
$this->_sections['phone']['index_next'] = $this->_sections['phone']['index'] + $this->_sections['phone']['step'];
$this->_sections['phone']['first']      = ($this->_sections['phone']['iteration'] == 1);
$this->_sections['phone']['last']       = ($this->_sections['phone']['iteration'] == $this->_sections['phone']['total']);
?>
		<?php echo smarty_function_cycle(array('values' => "odd,even",'assign' => 'rowClass'), $this);?>

		<tr class="<?php echo $this->_tpl_vars['rowClass']; ?>
">
		<td class="rowheader"><?php echo $this->_tpl_vars['ContactPhone'][$this->_sections['phone']['index']]['phone_type_name'];  if ($this->_tpl_vars['ContactPhone'][$this->_sections['phone']['index']]['preferred'] == 'Y'): ?><span style="color:#a00000;">*</span><?php endif; ?></td>
		<td><?php echo $this->_tpl_vars['ContactPhone'][$this->_sections['phone']['index']]['phone_number']; ?>
</td>
		<td class="options">
<?php if ($this->_tpl_vars['PERM_MODIFY']): ?><a class="adark" href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>?menuAction=htmlContactPhone.modify&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>&contact_phone_id=<?php echo $this->_tpl_vars['ContactPhone'][$this->_sections['phone']['index']]['contact_phone_id']; ?>"><?php echo @constant('STR_CMMN_EDIT'); ?></a>&nbsp;|&nbsp;<a class="adark" href="javascript:;" onclick="deletePhone(<?php echo $this->_tpl_vars['ContactPhone'][$this->_sections['phone']['index']]['contact_phone_id']; ?>);"><?php echo @constant('STR_CMMN_DELETE'); ?></a><?php endif; ?>
		</td>
	</tr>
<?php endfor; endif; ?>
	</tbody>
</table>
<table width="100%" class="dcl_results">
	<caption class="spacer"><?php echo @constant('STR_CM_EMAILADDRESSES'); ?>
E-Mail Addresses</caption>
	<thead>
		<tr class="toolbar"><th colspan="3"><ul><li class="first"><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContactEmail.add&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
"><?php echo @constant('STR_CMMN_NEW'); ?>
</a></li></ul></th></tr>
	</thead>
	<tbody>
<?php if (isset($this->_sections['email'])) unset($this->_sections['email']);
$this->_sections['email']['name'] = 'email';
$this->_sections['email']['loop'] = is_array($_loop=$this->_tpl_vars['ContactEmail']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);
$this->_sections['email']['show'] = true;
$this->_sections['email']['max'] = $this->_sections['email']['loop'];
$this->_sections['email']['step'] = 1;
$this->_sections['email']['start'] = $this->_sections['email']['step'] > 0 ? 0 : $this->_sections['email']['loop']-1;
if ($this->_sections['email']['show']) {
    $this->_sections['email']['total'] = $this->_sections['email']['loop'];
    if ($this->_sections['email']['total'] == 0)
        $this->_sections['email']['show'] = false;
} else
    $this->_sections['email']['total'] = 0;
if ($this->_sections['email']['show']):

            for ($this->_sections['email']['index'] = $this->_sections['email']['start'], $this->_sections['email']['iteration'] = 1;
                 $this->_sections['email']['iteration'] <= $this->_sections['email']['total'];
                 $this->_sections['email']['index'] += $this->_sections['email']['step'], $this->_sections['email']['iteration']++):
$this->_sections['email']['rownum'] = $this->_sections['email']['iteration'];
$this->_sections['email']['index_prev'] = $this->_sections['email']['index'] - $this->_sections['email']['step'];
$this->_sections['email']['index_next'] = $this->_sections['email']['index'] + $this->_sections['email']['step'];
$this->_sections['email']['first']      = ($this->_sections['email']['iteration'] == 1);
$this->_sections['email']['last']       = ($this->_sections['email']['iteration'] == $this->_sections['email']['total']);
?>
		<?php echo smarty_function_cycle(array('values' => "odd,even",'assign' => 'rowClass'), $this);?>

	<tr class="<?php echo $this->_tpl_vars['rowClass']; ?>
">
		<td class="rowheader"><?php echo $this->_tpl_vars['ContactEmail'][$this->_sections['email']['index']]['email_type_name'];  if ($this->_tpl_vars['ContactEmail'][$this->_sections['email']['index']]['preferred'] == 'Y'): ?><span style="color:#a00000;">*</span><?php endif; ?></td>
		<td><a href="mailto:<?php echo ((is_array($_tmp=$this->_tpl_vars['ContactEmail'][$this->_sections['email']['index']]['email_addr'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>
"><?php echo ((is_array($_tmp=$this->_tpl_vars['ContactEmail'][$this->_sections['email']['index']]['email_addr'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>
</a></td>
		<td class="options">
<?php if ($this->_tpl_vars['PERM_MODIFY']): ?><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>?menuAction=htmlContactEmail.modify&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>&contact_email_id=<?php echo $this->_tpl_vars['ContactEmail'][$this->_sections['email']['index']]['contact_email_id']; ?>"><?php echo @constant('STR_CMMN_EDIT'); ?></a>&nbsp;|&nbsp;<a href="javascript:;" onclick="deleteEmail(<?php echo $this->_tpl_vars['ContactEmail'][$this->_sections['email']['index']]['contact_email_id']; ?>);"><?php echo @constant('STR_CMMN_DELETE'); ?></a><?php endif; ?>
		</td>
	</tr>
<?php endfor; endif; ?>
	</tbody>
</table>
<table width="100%" class="dcl_results">
	<caption class="spacer"><?php echo @constant('STR_CM_URL'); ?>
URLs</caption>
	<thead>
		<tr class="toolbar"><th colspan="3"><ul><li class="first"><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContactUrl.add&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
"><?php echo @constant('STR_CMMN_NEW'); ?>
</a></li></ul></th></tr>
	</thead>
	<tbody>
<?php if (isset($this->_sections['url'])) unset($this->_sections['url']);
$this->_sections['url']['name'] = 'url';
$this->_sections['url']['loop'] = is_array($_loop=$this->_tpl_vars['ContactURL']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);
$this->_sections['url']['show'] = true;
$this->_sections['url']['max'] = $this->_sections['url']['loop'];
$this->_sections['url']['step'] = 1;
$this->_sections['url']['start'] = $this->_sections['url']['step'] > 0 ? 0 : $this->_sections['url']['loop']-1;
if ($this->_sections['url']['show']) {
    $this->_sections['url']['total'] = $this->_sections['url']['loop'];
    if ($this->_sections['url']['total'] == 0)
        $this->_sections['url']['show'] = false;
} else
    $this->_sections['url']['total'] = 0;
if ($this->_sections['url']['show']):

            for ($this->_sections['url']['index'] = $this->_sections['url']['start'], $this->_sections['url']['iteration'] = 1;
                 $this->_sections['url']['iteration'] <= $this->_sections['url']['total'];
                 $this->_sections['url']['index'] += $this->_sections['url']['step'], $this->_sections['url']['iteration']++):
$this->_sections['url']['rownum'] = $this->_sections['url']['iteration'];
$this->_sections['url']['index_prev'] = $this->_sections['url']['index'] - $this->_sections['url']['step'];
$this->_sections['url']['index_next'] = $this->_sections['url']['index'] + $this->_sections['url']['step'];
$this->_sections['url']['first']      = ($this->_sections['url']['iteration'] == 1);
$this->_sections['url']['last']       = ($this->_sections['url']['iteration'] == $this->_sections['url']['total']);
?>
		<?php echo smarty_function_cycle(array('values' => "odd,even",'assign' => 'rowClass'), $this);?>

	<tr class="<?php echo $this->_tpl_vars['rowClass']; ?>
">
		<td class="rowheader"><?php echo $this->_tpl_vars['ContactURL'][$this->_sections['url']['index']]['url_type_name'];  if ($this->_tpl_vars['ContactURL'][$this->_sections['url']['index']]['preferred'] == 'Y'): ?><span style="color:#a00000;">*</span><?php endif; ?></td>
		<td><a target="_blank" href="<?php echo ((is_array($_tmp=$this->_tpl_vars['ContactURL'][$this->_sections['url']['index']]['url_addr'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>
"><?php echo ((is_array($_tmp=$this->_tpl_vars['ContactURL'][$this->_sections['url']['index']]['url_addr'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>
</a></td>
		<td class="options">
<?php if ($this->_tpl_vars['PERM_MODIFY']): ?><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>?menuAction=htmlContactUrl.modify&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>&contact_url_id=<?php echo $this->_tpl_vars['ContactURL'][$this->_sections['url']['index']]['contact_url_id']; ?>"><?php echo @constant('STR_CMMN_EDIT'); ?></a>&nbsp;|&nbsp;<a href="javascript:;" onclick="deleteUrl(<?php echo $this->_tpl_vars['ContactURL'][$this->_sections['url']['index']]['contact_url_id']; ?>);"><?php echo @constant('STR_CMMN_DELETE'); ?></a><?php endif; ?>
		</td>
	</tr>
<?php endfor; endif; ?>
	</tbody>
</table>
<table width="100%" class="dcl_results">
	<caption class="spacer"><?php echo @constant('STR_CM_ORGANIZATIONS'); ?>
Organizations</caption>
	<thead>
		<?php if ($this->_tpl_vars['PERM_MODIFY']): ?><tr class="toolbar"><th colspan="5"><ul><li class="first"><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContactOrgs.modify&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
"><?php echo @constant('STR_CMMN_EDIT'); ?>
</a></li></ul></th></tr><?php endif; ?>
		<tr><?php if (count($_from = (array)$this->_tpl_vars['ViewOrg']->columnhdrs)):
    foreach ($_from as $this->_tpl_vars['col']):
?><th><?php echo $this->_tpl_vars['col']; ?>
</th><?php endforeach; unset($_from); endif; ?></tr>
	</thead>
	<tbody>
<?php if (isset($this->_foreach['orgs'])) unset($this->_foreach['orgs']);
$this->_foreach['orgs']['name'] = 'orgs';
$this->_foreach['orgs']['total'] = count($_from = (array)$this->_tpl_vars['Orgs']);
$this->_foreach['orgs']['show'] = $this->_foreach['orgs']['total'] > 0;
if ($this->_foreach['orgs']['show']):
$this->_foreach['orgs']['iteration'] = 0;
    foreach ($_from as $this->_tpl_vars['record']):
        $this->_foreach['orgs']['iteration']++;
        $this->_foreach['orgs']['first'] = ($this->_foreach['orgs']['iteration'] == 1);
        $this->_foreach['orgs']['last']  = ($this->_foreach['orgs']['iteration'] == $this->_foreach['orgs']['total']);
 echo smarty_function_cycle(array('values' => "odd,even",'assign' => 'rowClass'), $this);?><tr class="<?php echo $this->_tpl_vars['rowClass']; ?>"><?php if (isset($this->_foreach['org'])) unset($this->_foreach['org']);$this->_foreach['org']['name'] = 'org';$this->_foreach['org']['total'] = count($_from = (array)$this->_tpl_vars['record']);$this->_foreach['org']['show'] = $this->_foreach['org']['total'] > 0;if ($this->_foreach['org']['show']):$this->_foreach['org']['iteration'] = 0;foreach ($_from as $this->_tpl_vars['key'] => $this->_tpl_vars['data']):$this->_foreach['org']['iteration']++;$this->_foreach['org']['first'] = ($this->_foreach['org']['iteration'] == 1);$this->_foreach['org']['last']  = ($this->_foreach['org']['iteration'] == $this->_foreach['org']['total']); if (is_numeric ( $this->_tpl_vars['key'] )): ?><td><?php if ($this->_foreach['org']['iteration'] == 2): ?><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>?menuAction=htmlOrgDetail.show&org_id=<?php echo $this->_tpl_vars['record']['org_id']; ?>"><?php echo $this->_tpl_vars['data']; ?></a><?php elseif ($this->_foreach['org']['iteration'] == 4 && $this->_tpl_vars['data'] != ""):  echo smarty_function_mailto(array('address' => $this->_tpl_vars['data']), $this); elseif ($this->_foreach['org']['iteration'] == 5):  echo ((is_array($_tmp=$this->_tpl_vars['data'])) ? $this->_run_mod_handler('escape', true, $_tmp, 'link') : smarty_modifier_escape($_tmp, 'link'));  else:  echo $this->_tpl_vars['data'];  endif; ?></td><?php endif;  endforeach; unset($_from); endif; ?></tr>
<?php endforeach; unset($_from); endif; ?>
	</tbody>	
</table>
<table width="100%" class="dcl_results">
	<caption class="spacer"><?php echo @constant('STR_CM_PRODUCTLICENSES'); ?>
Product Licenses</caption>
	<thead>
		<?php if ($this->_tpl_vars['PERM_MODIFY']): ?><tr class="toolbar"><th colspan="<?php if ($this->_tpl_vars['PERM_MODIFY']): ?>6<?php else: ?>5<?php endif; ?>"><ul><li class="first"><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=htmlContactLicenses.add&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
"><?php echo @constant('STR_CMMN_NEW'); ?>
</a></li></ul></th></tr><?php endif; ?>
		<tr><th>Product</th><th>Version</th><th>License #</th><th>Registered On</th><th>Expires On</th><?php if ($this->_tpl_vars['PERM_MODIFY']): ?><th>Options</th><?php endif; ?></tr>
	</thead>
	<tbody>
<?php if (isset($this->_sections['license'])) unset($this->_sections['license']);
$this->_sections['license']['name'] = 'license';
$this->_sections['license']['loop'] = is_array($_loop=$this->_tpl_vars['ContactLicense']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);
$this->_sections['license']['show'] = true;
$this->_sections['license']['max'] = $this->_sections['license']['loop'];
$this->_sections['license']['step'] = 1;
$this->_sections['license']['start'] = $this->_sections['license']['step'] > 0 ? 0 : $this->_sections['license']['loop']-1;
if ($this->_sections['license']['show']) {
    $this->_sections['license']['total'] = $this->_sections['license']['loop'];
    if ($this->_sections['license']['total'] == 0)
        $this->_sections['license']['show'] = false;
} else
    $this->_sections['license']['total'] = 0;
if ($this->_sections['license']['show']):

            for ($this->_sections['license']['index'] = $this->_sections['license']['start'], $this->_sections['license']['iteration'] = 1;
                 $this->_sections['license']['iteration'] <= $this->_sections['license']['total'];
                 $this->_sections['license']['index'] += $this->_sections['license']['step'], $this->_sections['license']['iteration']++):
$this->_sections['license']['rownum'] = $this->_sections['license']['iteration'];
$this->_sections['license']['index_prev'] = $this->_sections['license']['index'] - $this->_sections['license']['step'];
$this->_sections['license']['index_next'] = $this->_sections['license']['index'] + $this->_sections['license']['step'];
$this->_sections['license']['first']      = ($this->_sections['license']['iteration'] == 1);
$this->_sections['license']['last']       = ($this->_sections['license']['iteration'] == $this->_sections['license']['total']);
?>
		<?php echo smarty_function_cycle(array('values' => "odd,even",'assign' => 'rowClass'), $this);?>

	<tr class="<?php echo $this->_tpl_vars['rowClass']; ?>
">
		<td><?php echo ((is_array($_tmp=$this->_tpl_vars['ContactLicense'][$this->_sections['license']['index']]['name'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>
</td>
		<td><?php echo ((is_array($_tmp=$this->_tpl_vars['ContactLicense'][$this->_sections['license']['index']]['product_version'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>
</td>
		<td><?php echo ((is_array($_tmp=$this->_tpl_vars['ContactLicense'][$this->_sections['license']['index']]['license_id'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>
</td>
		<td><?php echo ((is_array($_tmp=$this->_tpl_vars['ContactLicense'][$this->_sections['license']['index']]['registered_on'])) ? $this->_run_mod_handler('escape', true, $_tmp, 'date') : smarty_modifier_escape($_tmp, 'date')); ?>
</td>
		<td class="<?php if ($this->_tpl_vars['ContactLicense'][$this->_sections['license']['index']]['val_expires_on'] >= $this->_tpl_vars['VAL_TODAY']): ?>no<?php endif; ?>problem"><?php echo ((is_array($_tmp=$this->_tpl_vars['ContactLicense'][$this->_sections['license']['index']]['expires_on'])) ? $this->_run_mod_handler('escape', true, $_tmp, 'date') : smarty_modifier_escape($_tmp, 'date')); ?>
</td>
<?php if ($this->_tpl_vars['PERM_MODIFY']): ?><td class="options"><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>?menuAction=htmlContactLicenses.modify&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>&contact_license_id=<?php echo $this->_tpl_vars['ContactLicense'][$this->_sections['license']['index']]['contact_license_id']; ?>"><?php echo @constant('STR_CMMN_EDIT'); ?></a>&nbsp;|&nbsp;<a href="javascript:;" onclick="deleteLicense(<?php echo $this->_tpl_vars['ContactLicense'][$this->_sections['license']['index']]['contact_license_id']; ?>);"><?php echo @constant('STR_CMMN_DELETE'); ?></a></td><?php endif; ?>
	</tr>
	<?php if ($this->_tpl_vars['ContactLicense'][$this->_sections['license']['index']]['license_notes'] != ''): ?>
	<tr>
		<td>&nbsp;</td>
		<td class="notes" colspan="<?php if ($this->_tpl_vars['PERM_MODIFY']): ?>5<?php else: ?>4<?php endif; ?>"><b>Notes: </b><?php echo ((is_array($_tmp=$this->_tpl_vars['ContactLicense'][$this->_sections['license']['index']]['license_notes'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>
</td>
	</tr>
	<?php endif; ?>
<?php endfor; endif; ?>
	</tbody>
</table>
<table width="100%" class="dcl_results">
	<caption class="spacer"><?php echo @constant('STR_CM_LAST10TICKETS'); ?>
Last 10 Tickets</caption>
	<thead><tr class="toolbar"><th colspan="7"><ul><li class="first"><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=boTickets.add&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
"><?php echo @constant('STR_CMMN_NEW'); ?>
</a></li></ul></th></tr>
		<tr><?php if (count($_from = (array)$this->_tpl_vars['ViewTicket']->columnhdrs)):
    foreach ($_from as $this->_tpl_vars['col']):
?><th><?php echo $this->_tpl_vars['col']; ?>
</th><?php endforeach; unset($_from); endif; ?></tr>
	</thead>
	<tbody>
<?php if (isset($this->_foreach['tickets'])) unset($this->_foreach['tickets']);
$this->_foreach['tickets']['name'] = 'tickets';
$this->_foreach['tickets']['total'] = count($_from = (array)$this->_tpl_vars['Tickets']);
$this->_foreach['tickets']['show'] = $this->_foreach['tickets']['total'] > 0;
if ($this->_foreach['tickets']['show']):
$this->_foreach['tickets']['iteration'] = 0;
    foreach ($_from as $this->_tpl_vars['record']):
        $this->_foreach['tickets']['iteration']++;
        $this->_foreach['tickets']['first'] = ($this->_foreach['tickets']['iteration'] == 1);
        $this->_foreach['tickets']['last']  = ($this->_foreach['tickets']['iteration'] == $this->_foreach['tickets']['total']);
?>
	<?php echo smarty_function_cycle(array('values' => "odd,even",'assign' => 'rowClass'), $this);?>

	<tr class="<?php echo $this->_tpl_vars['rowClass']; ?>
">
	<?php if (isset($this->_foreach['ticket'])) unset($this->_foreach['ticket']);
$this->_foreach['ticket']['name'] = 'ticket';
$this->_foreach['ticket']['total'] = count($_from = (array)$this->_tpl_vars['record']);
$this->_foreach['ticket']['show'] = $this->_foreach['ticket']['total'] > 0;
if ($this->_foreach['ticket']['show']):
$this->_foreach['ticket']['iteration'] = 0;
    foreach ($_from as $this->_tpl_vars['key'] => $this->_tpl_vars['data']):
        $this->_foreach['ticket']['iteration']++;
        $this->_foreach['ticket']['first'] = ($this->_foreach['ticket']['iteration'] == 1);
        $this->_foreach['ticket']['last']  = ($this->_foreach['ticket']['iteration'] == $this->_foreach['ticket']['total']);
?>
	<?php if (is_numeric ( $this->_tpl_vars['key'] )): ?><td><?php if ($this->_foreach['ticket']['first']): ?><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=boTickets.view&ticketid=<?php echo $this->_tpl_vars['record']['ticketid']; ?>
"><?php echo $this->_tpl_vars['data']; ?>
</a><?php else:  echo $this->_tpl_vars['data'];  endif; ?></td><?php endif; ?>
	<?php endforeach; unset($_from); endif; ?>
	</tr>
<?php endforeach; unset($_from); endif; ?>
	</tbody>
</table>
<table width="100%" class="dcl_results">
	<caption class="spacer"><?php echo @constant('STR_CM_LAST10WORKORDERS'); ?>
Last 10 Work Orders</caption>
	<thead><tr class="toolbar"><th colspan="9"><ul><li class="first"><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=boWorkorders.newjcn&contact_id=<?php echo $this->_reg_objects['Contact'][0]->contact_id;?>
"><?php echo @constant('STR_CMMN_NEW'); ?>
</a></li></ul></th></tr>
		<tr><?php if (count($_from = (array)$this->_tpl_vars['ViewWorkOrder']->columnhdrs)):
    foreach ($_from as $this->_tpl_vars['col']):
?><th><?php echo $this->_tpl_vars['col']; ?>
</th><?php endforeach; unset($_from); endif; ?></tr>
	</thead>
	<tbody>
<?php if (isset($this->_foreach['workorders'])) unset($this->_foreach['workorders']);
$this->_foreach['workorders']['name'] = 'workorders';
$this->_foreach['workorders']['total'] = count($_from = (array)$this->_tpl_vars['WorkOrders']);
$this->_foreach['workorders']['show'] = $this->_foreach['workorders']['total'] > 0;
if ($this->_foreach['workorders']['show']):
$this->_foreach['workorders']['iteration'] = 0;
    foreach ($_from as $this->_tpl_vars['record']):
        $this->_foreach['workorders']['iteration']++;
        $this->_foreach['workorders']['first'] = ($this->_foreach['workorders']['iteration'] == 1);
        $this->_foreach['workorders']['last']  = ($this->_foreach['workorders']['iteration'] == $this->_foreach['workorders']['total']);
?>
	<?php echo smarty_function_cycle(array('values' => "odd,even",'assign' => 'rowClass'), $this);?>

	<tr class="<?php echo $this->_tpl_vars['rowClass']; ?>
">
	<?php if (isset($this->_foreach['wo'])) unset($this->_foreach['wo']);
$this->_foreach['wo']['name'] = 'wo';
$this->_foreach['wo']['total'] = count($_from = (array)$this->_tpl_vars['record']);
$this->_foreach['wo']['show'] = $this->_foreach['wo']['total'] > 0;
if ($this->_foreach['wo']['show']):
$this->_foreach['wo']['iteration'] = 0;
    foreach ($_from as $this->_tpl_vars['key'] => $this->_tpl_vars['data']):
        $this->_foreach['wo']['iteration']++;
        $this->_foreach['wo']['first'] = ($this->_foreach['wo']['iteration'] == 1);
        $this->_foreach['wo']['last']  = ($this->_foreach['wo']['iteration'] == $this->_foreach['wo']['total']);
?>
	<?php if (is_numeric ( $this->_tpl_vars['key'] )): ?>
	<td><?php if ($this->_foreach['wo']['iteration'] < 3): ?><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=boWorkorders.viewjcn&jcn=<?php echo $this->_tpl_vars['record']['jcn']; ?>
&seq=<?php echo $this->_tpl_vars['record']['seq']; ?>
"><?php echo $this->_tpl_vars['data']; ?>
</a><?php else:  echo $this->_tpl_vars['data'];  endif; ?></td>
	<?php endif; ?>
	<?php endforeach; unset($_from); endif; ?>
	</tr>
<?php endforeach; unset($_from); endif; ?>
	</tbody>
</table>