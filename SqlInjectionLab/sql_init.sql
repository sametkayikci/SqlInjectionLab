CREATE TABLE IF NOT EXISTS users(
    id SERIAL PRIMARY KEY,
    username TEXT,
    password TEXT,
    role TEXT
);

INSERT INTO users (username, password, role) VALUES
('admin', '123', 'admin'),
('alice', '123', 'user'),
('bob', '123', 'user')
ON CONFLICT DO NOTHING;

CREATE TABLE IF NOT EXISTS products(
    id SERIAL PRIMARY KEY,
    name TEXT,
    price NUMERIC
);

INSERT INTO products(name, price) VALUES
('Laptop', 12000),
('Telefon', 8000),
('Kulaklýk', 900)
ON CONFLICT DO NOTHING;
