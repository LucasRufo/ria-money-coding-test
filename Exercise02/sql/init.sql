CREATE TABLE IF NOT EXISTS customers (
    id INTEGER PRIMARY KEY,
    first_name VARCHAR(200) NOT NULL,
    last_name VARCHAR(200) NOT NULL,
    age INTEGER NOT NULL
);

CREATE INDEX idx_customers_first_name_last_name ON customers (first_name, last_name);