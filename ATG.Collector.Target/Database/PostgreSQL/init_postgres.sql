-- Create the database
CREATE DATABASE atg;

-- Switch to the atg database
\c atg;

-- Create the dataraw table
CREATE TABLE dataraw (
    key VARCHAR(255) PRIMARY KEY NOT NULL,
    tstamp TIMESTAMP WITH TIME ZONE NOT NULL,
    row_key VARCHAR(255) NOT NULL,
    string_value VARCHAR(255),
    int_value INTEGER,
    long_value BIGINT,
    bool_value BOOLEAN,
    tstamp_value TIMESTAMP WITH TIME ZONE
);

-- Create the necessary indexes
CREATE INDEX idx_row_key ON dataraw (row_key);
CREATE INDEX idx_tstamp ON dataraw (tstamp);
