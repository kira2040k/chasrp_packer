.\packer.exe $args[0]    
csc -out:$args[1] packer_execute2.cs 
for ($num = 1 ; $num -le $args[2] ; $num++)

{
	.\packer.exe $args[1]   
	csc -out:$args[1] packer_execute2.cs
	$num
}
	
