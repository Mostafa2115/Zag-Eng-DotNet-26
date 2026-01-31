create proc sp_ApplyCategoryDiscount
    @CatID int,
    @DiscountPercent decimal(5,2)
as
begin
    update Products
    set price =
        case when price - (price * @DiscountPercent / 100) < min_price 
		          then min_price
          else price - (price * @DiscountPercent / 100)
        end
    where category_id = @CatID;
end;
