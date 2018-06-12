<?php
if ($_POST['username'] === 'admin' && $_POST['password'] === 'hermahiggins') {
	echo 'MC{s4lt_aNd_p5pper_4r3_n0t_jus_f0r_c0oking}';
} else {
	header("Location: http://chal.gryphonctf.com:7000/?login=failed");
	die();
}
?>