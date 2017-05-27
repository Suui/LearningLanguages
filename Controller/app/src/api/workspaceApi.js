export function createVocabularyFolder(folderName) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve({ 
                id: 3,
                name: folderName
            });
        }, 1000);
    });
}

export function retrieveVocabularyFolders() {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve([
                {
                    id: 1,
                    name: 'Parrot Words'
                },
                {
                    id: 2,
                    name: 'Spanglish'
                }
            ]);
        }, 1000);
    });
}