export function createVocabularyFolder(folderName) {
    return fetch({

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