// Converte a primeira letra de cada palavra para maiúscula
// Exemplo: "IPA CLÁSSICA" → "Ipa Clássica"
export function toTitleCase(text: string): string {
    return text
        .toLowerCase()
        .replace(/\b\w/g, letter => letter.toUpperCase());
}

// Converte todo o texto para maiúscula
// Exemplo: "ipa clássica" → "IPA CLÁSSICA"
export function toUpperCase(text: string): string {
    return text.toUpperCase();
}