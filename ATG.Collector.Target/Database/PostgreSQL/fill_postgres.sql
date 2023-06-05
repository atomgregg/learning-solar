INSERT INTO DataRaw (key, tstamp, row_key, int_value)
SELECT
    ts.key,
    ts.ts,
    rk,
    CASE
        WHEN date_part('month', ts.ts) < 2 THEN (random() * 100) + 120 + (date_part('hour', ts.ts) * 10)
        WHEN date_part('month', ts.ts) < 3 THEN (random() * 140) + 200 + (date_part('hour', ts.ts) * 10)
        WHEN date_part('month', ts.ts) < 4 THEN (random() * 160) + 220 + (date_part('hour', ts.ts) * 10)
        WHEN date_part('month', ts.ts) < 5 THEN (random() * 160) + 250 + (date_part('hour', ts.ts) * 10)
        WHEN date_part('month', ts.ts) < 6 THEN (random() * 200) + 300 + (date_part('hour', ts.ts) * 10)
        WHEN date_part('month', ts.ts) < 7 THEN (random() * 300) + 300 + (date_part('hour', ts.ts) * 10)
        WHEN date_part('month', ts.ts) < 8 THEN (random() * 300) + 300 + (date_part('hour', ts.ts) * 10)
        WHEN date_part('month', ts.ts) < 9 THEN (random() * 200) + 300 + (date_part('hour', ts.ts) * 10)
        WHEN date_part('month', ts.ts) < 10 THEN (random() * 160) + 250 + (date_part('hour', ts.ts) * 10)
        WHEN date_part('month', ts.ts) < 11 THEN (random() * 160) + 220 + (date_part('hour', ts.ts) * 10)
        WHEN date_part('month', ts.ts) < 12 THEN (random() * 140) + 200 + (date_part('hour', ts.ts) * 10)
        WHEN date_part('month', ts.ts) < 13 THEN (random() * 100) + 120 + (date_part('hour', ts.ts) * 10)
    END
FROM (
    SELECT
        gen_random_uuid()::text AS key,
        ts
    FROM generate_series('2022-06-01 00:00:00'::timestamp, '2023-06-01 23:59:00'::timestamp, '1 minute') AS ts
) AS ts
CROSS JOIN unnest(ARRAY['String1', 'String2', 'String3']) AS rk;
