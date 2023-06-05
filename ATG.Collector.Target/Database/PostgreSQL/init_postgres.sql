-- Create the database
CREATE DATABASE atg;

-- Switch to the atg database
\c atg;

-- Create the dataraw table
CREATE TABLE DataRaw (
    key TEXT NOT NULL,
    tstamp TIMESTAMPTZ NOT NULL,
    row_key TEXT NOT NULL,
    string_value TEXT,
    int_value INT,
    long_value BIGINT,
    bool_value BOOLEAN,
    tstamp_value TIMESTAMPTZ,
    CONSTRAINT pk_data_raw PRIMARY KEY (key, row_key)
);

-- Create the necessary indexes
CREATE INDEX idx_tstamp ON dataraw (tstamp);
