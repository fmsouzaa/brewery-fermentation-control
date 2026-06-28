export function toTitleCase(text: string): string {
    return text
        .toLowerCase()
        .replace(/\b\w/g, letter => letter.toUpperCase());
}

export function toUpperCase(text: string): string {
    return text.toUpperCase();
}