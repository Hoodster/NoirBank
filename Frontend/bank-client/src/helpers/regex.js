const regex = {
    docIDPattern: '([A-Z]{3})(\s{0,1})([0-9]{6})',
    wordNoNumPattern:'\b[^\\d\\W]+\b',
    personalIDPattern: '[0-9]{11}',
    postalCodePattern: '([0-9]{2})([-]{0,1})([0-9]{3})'
}

export const {docIDPattern, wordNoNumPattern, personalIDPattern, postalCodePattern} = regex
export default regex