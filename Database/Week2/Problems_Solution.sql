/* problem 1 */
SELECT Product.product_name, Sales.year, Sales.price
FROM Sales 
INNER JOIN Product 
ON Sales.product_id = Product.product_id;

/* problem 2 */
SELECT Visits.customer_id, COUNT(Visits.visit_id) AS count_no_trans 
FROM Visits 
LEFT JOIN Transactions 
ON Visits.visit_id = Transactions.visit_id  
WHERE Transactions.transaction_id IS NULL 
GROUP BY Visits.customer_id;

/* problem 3 */
SELECT EmployeeUNI.unique_id AS unique_id, Employees.name AS name
FROM Employees 
LEFT JOIN EmployeeUNI 
ON Employees.id = EmployeeUNI.id;

/* problem 4 */
SELECT W1.id
FROM Weather W1
INNER JOIN Weather W2
ON DATEDIFF(W1.recordDate, W2.recordDate) = 1
WHERE W1.temperature > W2.temperature;
