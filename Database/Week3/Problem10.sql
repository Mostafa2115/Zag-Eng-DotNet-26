create view VIPCustomers_v
as
select c.name,c.email,sum(o.amount_total) AS total_spent
from Customers c join Orders o on c.customer_id = o.customer_id
group by c.customer_id, c.name,c.email
having sum(o.amount_total) > 5000;
