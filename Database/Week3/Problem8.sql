-- وجود index مش معناه performance اعلى ولكن لازم index يحتوي على كل الأعمدة اللي الـ Query محتاجاها 
create index Orders_Covering
on Orders (order_date, customer_id, total_amount);
