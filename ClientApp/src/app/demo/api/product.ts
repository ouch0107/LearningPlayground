interface InventoryStatus {
    label: string;
    value: string;
}
export interface Product {
    id?: string;
    code?: string;
    name?: string;
    description?: string;
    price?: number;
    quantity?: number;
    inventoryStatus?: InventoryStatus;
    category?: string;
    image?: string;
    rating?: number;
}
// 測試API用
export interface CustomProduct {
    productID: number,
    name: string,
    productNumber: string,
    color?: string,
    standardCost: number,
    listPrice: number,
    size?: string,
    weight?: number
}