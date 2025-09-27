Create Proc GetDonationReceiept
(
	@ReceiptNo int
)
As
BEGIN
	Select * from donations Where receipt_number=@ReceiptNo
END