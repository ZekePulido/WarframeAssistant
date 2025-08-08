// server.mjs
import express from 'express';
import Items from '@wfcd/items';

const app = express();
const port = 3001;

// Load all item data
const items = new Items();

// Create a map of category -> list of items
function groupItemsByCategory(items) {
    const categories = {};

    items.forEach(item => {
        const category = item.category || 'Unknown';
        if (!categories[category]) {
            categories[category] = [];
        }
        categories[category].push(item);
    });

    return categories;
}

const groupedItems = groupItemsByCategory(items);

// Route to get all categories
app.get('/categories', (req, res) => {
    res.json(Object.keys(groupedItems));
});

// Route to get all items in a specific category
app.get('/items/category/:categoryName', (req, res) => {
    const { categoryName } = req.params;
    const itemsInCategory = groupedItems[categoryName];

    if (!itemsInCategory) {
        return res.status(404).json({ error: 'Category not found' });
    }
    
    const slimmed = itemsInCategory.map(({ name, imageName, category, drops }) => ({
        name,
        imageName,
        category,
        drops
    }));

    res.json(slimmed);
});


app.listen(port, () => {
    console.log(`WFCD API running at http://localhost:${port}`);
});
