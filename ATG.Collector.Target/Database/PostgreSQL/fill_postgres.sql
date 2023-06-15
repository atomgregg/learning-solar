INSERT INTO DataRaw (key, tstamp, row_key, int_value)
SELECT
    ts.key,
    ts.ts,
    rk,
    CASE
        WHEN date_part('month', ts.ts) < 2 THEN ROUND(CAST(((random() * 0.3 + 0.7) * 650 * exp(-0.4 * (date_part('hour', ts.ts) - 7) * (date_part('hour', ts.ts) - 7))) AS numeric), 2)
        WHEN date_part('month', ts.ts) < 3 THEN ROUND(CAST(((random() * 0.3 + 0.7) * 650 * exp(-0.4 * (date_part('hour', ts.ts) - 7) * (date_part('hour', ts.ts) - 7))) AS numeric), 2)
        WHEN date_part('month', ts.ts) < 4 THEN ROUND(CAST(((random() * 0.3 + 0.7) * 650 * exp(-0.4 * (date_part('hour', ts.ts) - 7) * (date_part('hour', ts.ts) - 7))) AS numeric), 2)
        WHEN date_part('month', ts.ts) < 5 THEN ROUND(CAST(((random() * 0.3 + 0.7) * 650 * exp(-0.4 * (date_part('hour', ts.ts) - 7) * (date_part('hour', ts.ts) - 7))) AS numeric), 2)
        WHEN date_part('month', ts.ts) < 6 THEN ROUND(CAST(((random() * 0.3 + 0.7) * 650 * exp(-0.4 * (date_part('hour', ts.ts) - 7) * (date_part('hour', ts.ts) - 7))) AS numeric), 2)
        WHEN date_part('month', ts.ts) < 7 THEN ROUND(CAST(((random() * 0.3 + 0.7) * 650 * exp(-0.4 * (date_part('hour', ts.ts) - 7) * (date_part('hour', ts.ts) - 7))) AS numeric), 2)
        WHEN date_part('month', ts.ts) < 8 THEN ROUND(CAST(((random() * 0.3 + 0.7) * 650 * exp(-0.4 * (date_part('hour', ts.ts) - 7) * (date_part('hour', ts.ts) - 7))) AS numeric), 2)
        WHEN date_part('month', ts.ts) < 9 THEN ROUND(CAST(((random() * 0.3 + 0.7) * 650 * exp(-0.4 * (date_part('hour', ts.ts) - 7) * (date_part('hour', ts.ts) - 7))) AS numeric), 2)
        WHEN date_part('month', ts.ts) < 10 THEN ROUND(CAST(((random() * 0.3 + 0.7) * 650 * exp(-0.4 * (date_part('hour', ts.ts) - 7) * (date_part('hour', ts.ts) - 7))) AS numeric), 2)
        WHEN date_part('month', ts.ts) < 11 THEN ROUND(CAST(((random() * 0.3 + 0.7) * 650 * exp(-0.4 * (date_part('hour', ts.ts) - 7) * (date_part('hour', ts.ts) - 7))) AS numeric), 2)
        WHEN date_part('month', ts.ts) < 12 THEN ROUND(CAST(((random() * 0.3 + 0.7) * 650 * exp(-0.4 * (date_part('hour', ts.ts) - 7) * (date_part('hour', ts.ts) - 7))) AS numeric), 2)
        WHEN date_part('month', ts.ts) < 13 THEN ROUND(CAST(((random() * 0.3 + 0.7) * 650 * exp(-0.4 * (date_part('hour', ts.ts) - 7) * (date_part('hour', ts.ts) - 7))) AS numeric), 2)
    END
FROM (
    SELECT
        gen_random_uuid()::text AS key,
        ts
    FROM generate_series('2022-06-15 00:00:00'::timestamp, '2023-06-15 23:59:00'::timestamp, '1 minute') AS ts
) AS ts
CROSS JOIN unnest(ARRAY['String1', 'String2', 'String3']) AS rk;
