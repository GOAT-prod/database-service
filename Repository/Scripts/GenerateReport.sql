WITH ItemDetails AS (SELECT op.date,
                            p.name                     AS ProductName,
                            pri.color                  AS Color,
                            pri.size                   AS Size,
    SUM(oi.quantity)           AS TotalCount,
    SUM(oi.quantity * p.price) AS TotalPrice
FROM orders o
    JOIN orders_item oi ON oi.order_id = o.id
    JOIN product_item pri ON oi.product_item_id = pri.id
    JOIN product p ON pri.product_id = p.id
    JOIN operation op ON o.id = op.order_id
GROUP BY op.date, p.name, pri.color, pri.size),
    ReportSummary AS (SELECT op.date,
    SUM(opd.amount) AS TotalPrice
FROM orders o
    JOIN operation op ON o.id = op.order_id
    JOIN operation_detail opd ON op.id = opd.operation_id
GROUP BY op.date)
SELECT rs.date,
       rs.TotalPrice,
       JSON_AGG(
               JSON_BUILD_OBJECT(
                       'ProductName', id.ProductName,
                       'Color', id.Color,
                       'Size', id.Size,
                       'TotalCount', id.TotalCount,
                       'TotalPrice', id.TotalPrice
               )
       ) AS Items
FROM ReportSummary rs
         JOIN ItemDetails id ON rs.date = id.date
GROUP BY rs.date, rs.TotalPrice;