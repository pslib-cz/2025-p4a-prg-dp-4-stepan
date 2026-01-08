# Navigační Systém - Návrhový Vzor Composite

## Zadání
Vytvořit menu stromové struktury bez použití if else, 
    Zobraz()
        js
        react
        react-router
            -typescript
            -javascript

možnost koncová položka - spustí akci
nekoncová - dajší možnosti


## Návrhový Vzor: Composite (Kompozit)

### Proč Composite?
- Řeší stromové struktury (část-celek).
- Umožňuje pracovat s jednou položkou i se skupinou stejně.
- Odstraňuje nutnost zjišťovat typ objektu (žádné `if` nebo `switch`).

### Implementace
Kód tvoří tři základní části:

1. **MenuComponent** (Rozhraní)
   - Společný základ, definuje metodu `Zobraz()`.
2. **MenuItem** (List/Položka)
   - Koncový prvek, jen se vypíše.
3. **MenuCategory** (Kontejner)
   - Obsahuje seznam dětí.
   - Vypíše sebe -> zavolá `Zobraz()` na všechny děti.

### Výhody
- Jednoduché přidávání nových položek.
- Rekurze zařídí výpis do hloubky sama.
- Přehledný kód bez zbytečných podmínek.
