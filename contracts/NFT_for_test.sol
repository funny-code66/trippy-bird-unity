// SPDX-License-Identifier: MIT
pragma solidity 0.8.14;

import "@openzeppelin/contracts/token/ERC721/extensions/ERC721Enumerable.sol";

contract NFT_FOR_TEST is ERC721Enumerable {
    constructor() ERC721("NFT_FOR_TEST", "NFT") {}
}
