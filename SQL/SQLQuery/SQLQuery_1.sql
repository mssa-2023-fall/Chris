SELECT SUM(o.[Total Excluding Tax]) AS Total, d.[calendar year] AS FiscalYear
FROM Fact.[Order] o JOIN Dimension.Date d ON o.[Order Date Key] = d.Date
GROUP BY d.[calendar year]