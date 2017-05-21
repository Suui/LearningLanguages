export function displayVocabularyFolderCreation(displayed) {
    return { type: 'DISPLAY_VOCABULARY_FOLDER_CREATION', displayed };
}

export function createVocabularyFolder(folderName) {
    return { type: 'CREATE_VOCABULARY_FOLDER', folderName };
}