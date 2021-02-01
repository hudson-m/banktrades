create procedure dbo.spTradeRisk
	@Value	decimal(18,2),
	@IsPrivate	INTEGER
as
begin
	SET NOCOUNT ON;
	SELECT @Value AS 'Value',@IsPrivate AS 'IsPrivate'

	select case 
		WHEN @IsPrivate != 1	AND @Value < 1000000  then (SELECT @Value, @IsPrivate, 'LOWRISK' as Risk)
		WHEN @IsPrivate != 1	AND @Value >= 1000000 then (SELECT @Value, @IsPrivate, 'MEDIUMRISK'  as Risk)
		WHEN @IsPrivate != 0	AND @Value > 1000000  then (SELECT @Value, @IsPrivate, 'HIGHRISK' as Risk)
		else (SELECT @Value, @IsPrivate, 'NOTCALCULATEDRISK' as Risk)
	end

end