<?php
	require "config/connect.php";
	if(isset($_POST["update"]))
	{       $P_ID = $_POST["P_ID"];
		    $P_Name = $_POST["P_Name"];
			$P_Price = $_POST["P_Price"];
			$P_Size = $_POST["P_Size"];
			$P_Material = $_POST["P_Material"];
			$P_Code = $_POST["P_Code"];
			$P_Image = $_POST["P_Image"];
			$P_Description = $_POST["P_Description"];
			$P_Status = $_POST["P_Status"];
		$sql1 = "UPDATE product SET Product_Name=N'$P_Name',Product_Price='$P_Price',Product_Size='$P_Size',Product_Material='$P_Material',Product_Code='$P_Code',Product_Image='$target_file',Product_Description='$P_Description',Product_Status=N'$P_Status' WHERE Product_ID=$P_ID";

		if (mysqli_query($conn, $sql1)) {
			echo "Record updated successfully";
			header("location:product.php");
		} 
		else {
			echo "Error updating record: " . mysqli_error($conn);
		}
	}
?>
<html>
	<head>
		<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
	</head>
	<body>
		<div class="container">
			<h1 style="text-align:center;font-size:28px;margin:30px 0px;">TRANG CẬP NHẬT DANH MỤC SẢN PHẨM</h1>
			<div class="row">
				<div class="col-6">
					<form action="update_product.php" method="post">
						<?php
							if(isset($_GET["id"]))
							{
								$cate_id = $_GET["id"];
								$sql_select = "select * from product where Product_ID=$P_ID";
								$result = mysqli_query($conn,$sql_select);
								if (mysqli_num_rows($result) > 0) 
								{
									// output data of each row
									while($row = mysqli_fetch_assoc($result)) 
									{
										echo "<input name='cate_id' type='hidden' value='".$row["Product_ID"]."'>";
                                        echo "Tên sản phẩm:";
                                        echo "<input value='".$row['Product_Name']."' class='form-control' type='text' name='cate_name'/>";
                                        echo "Giá:";
                                        echo "<<input value='".$row['Product_Name']."' class='form-control' type='text' name='cate_name'/>";
                                        echo "Kích Thước:";
                                        echo "<<input value='".$row['Product_Name']."' class='form-control' type='text' name='cate_name'/>";
                                        echo "Vật liệu:";
                                        echo "<input value='".$row['Product_Name']."' class='form-control' type='text' name='cate_name'/>";
                                        echo "Mã danh mục :";
                                        echo "<input value='".$row['Product_Name']."' class='form-control' type='text' name='cate_name'/>";
                                        echo "Hình ảnh:";
                                        echo "<input value='".$row['Product_Name']."' class='form-control' type='text' name='cate_name'/>";
                                        echo "Mô tả sản phẩm:";
                                        echo "<input value='".$row['Product_Name']."' class='form-control' type='text' name='cate_name'/>";
                                        echo"<script>;
                                                CKEDITOR.replace( 'Product_Description' );
                                        </script>";
                                        echo "Trạng thái:";
                                        echo "<input value='".$row['Product_Name']."' class='form-control' type='text' name='cate_name'/>";
										
									
									}
								} 
								else {
									echo "0 results";
								}
							}
						?>
						
						<input class="btn btn-primary" type="submit" name="update" value="Chỉnh sửa">
					</form>
				</div>
			</div>
			
		</div>
	</body>
</html>
