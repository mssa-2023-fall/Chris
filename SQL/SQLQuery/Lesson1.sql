SELECT DISTINCT  [Postal Code] from Dimension.Customer;

SELECT [Customer Key], Customer, [Valid From] from Dimension.Customer WHERE [Postal Code] = @postalcode;