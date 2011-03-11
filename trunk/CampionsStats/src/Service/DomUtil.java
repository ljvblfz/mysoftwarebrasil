package Service;


import java.io.IOException;
import java.io.InputStream;
import java.io.PrintStream;
import java.io.PrintWriter;
import java.io.StringWriter;
import java.util.ArrayList;
import java.util.List;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;


import org.w3c.dom.DOMImplementation;
import org.w3c.dom.Document;
import org.w3c.dom.DocumentType;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.w3c.dom.Text;
import org.xml.sax.EntityResolver;
import org.xml.sax.InputSource;
import org.xml.sax.SAXException;

/**
 * A utility class which provides methods for working with a W3C DOM.
 */
public class DomUtil {
    
    /**
     * Entity resolver which throws a SAXException when invoked to avoid external entity injection.
     */
    private static final EntityResolver entityResolver = new EntityResolver() {
    
        /**
         * @see org.xml.sax.EntityResolver#resolveEntity(java.lang.String, java.lang.String)
         */
        public InputSource resolveEntity(String publicId, String systemId)
        throws SAXException, IOException {
            throw new SAXException("External entities not supported.");
        }
    };

    /**
     * ThreadLocal cache of <code>DocumentBuilder</code> instances.
     */
    private static final ThreadLocal<DocumentBuilder> documentBuilders = new ThreadLocal<DocumentBuilder>() {
    
        /**
         * @see java.lang.ThreadLocal#initialValue()
         */
        @Override
		protected DocumentBuilder initialValue() {
            try {
                DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
                DocumentBuilder builder = factory.newDocumentBuilder();
                builder.setEntityResolver(entityResolver);
                return builder;
            } catch (ParserConfigurationException ex) {
                throw new RuntimeException(ex);
            }
        }
    };
    
    /**
     * Creates a new document.
     * 
     * @param qualifiedName the qualified name of the document type to be 
     *        created
     * @param publicId the external subset public identifier
     * @param systemId the external subset system identifier
     * @param namespaceUri the namespace URI of the document element to create
     */
    public static Document createDocument(String qualifiedName, String publicId, String systemId, String namespaceUri) {
        DOMImplementation dom = DomUtil.getDocumentBuilder().getDOMImplementation();
        DocumentType docType = dom.createDocumentType(qualifiedName, publicId, systemId);
        Document document = dom.createDocument(namespaceUri, qualifiedName, docType);
        if (namespaceUri != null) {
            document.getDocumentElement().setAttribute("xmlns", namespaceUri);
        }
        return document;
    }

    /**
     * Retrieves a thread-specific <code>DocumentBuilder</code>.
     * 
     * @return the <code>DocumentBuilder</code> serving the current thread.
     */
    public static DocumentBuilder getDocumentBuilder() {
        return documentBuilders.get();
    }
    
    /**
     * Determines whether a specific boolean flag is set on an element.
     * 
     * @param element The element to analyze.
     * @param attributeName The name of the boolean 'flag' attribute.
     * @return True if the value of the attribute is 'true', false if it is
     *         not or if the attribute does not exist.
     */
    public static boolean getBooleanAttribute(Element element, String attributeName) {
        String value = element.getAttribute(attributeName);
        if (value == null) {
            return false;
        } else if (value.equals("true")) {
            return true;
        } else {
            return false;
        }
    }

    /**
     * Retrieves the first immediate child element of the specified element  
     * whose name matches the provided <code>name</code> parameter.
     * 
     * @param parentElement The element to search.
     * @param name The name of the child element.
     * @return The child element, or null if none was found. 
     */
    public static Element getChildElementByTagName(Element parentElement, String name) {
        NodeList nodes = parentElement.getChildNodes();
        int length = nodes.getLength();
        for (int index = 0; index < length; ++index) {
            if (nodes.item(index).getNodeType() == Node.ELEMENT_NODE
                    && name.equals(nodes.item(index).getNodeName())) {
                return (Element) nodes.item(index);
            }
        }
        return null;
    }
    
    public static String getPropertyElementValue(Element parentElement, String propertyElementName) {
        Element childElement = getChildElementByTagName(parentElement, propertyElementName);
        if (childElement == null) {
            return null;
        }
        return getElementText(childElement);
    }
    
    /**
     * Retrieves all immediate child elements of the specified element whose
     * names match the provided <code>name</code> parameter.
     * 
     * @param parentElement The element to search.
     * @param name The name of the child element.
     * @return An array of matching child elements.
     */
    public static Element[] getChildElementsByTagName(Element parentElement, String name) {
        List<Element> children = new ArrayList<Element>();
        NodeList nodes = parentElement.getChildNodes();
        int length = nodes.getLength();
        for (int index = 0; index < length; ++index) {
            if (nodes.item(index).getNodeType() == Node.ELEMENT_NODE
                    && name.equals(nodes.item(index).getNodeName())) {
                children.add((Element) nodes.item(index));
            }
        }
        return (Element[]) children.toArray();
    }

    /**
     * Counts the number of immediate child elements of the specified element
     * whose names match the provided <code>name</code> parameter.
     * 
     * @param parentElement The element to analyze.
     * @param name The name of the child element.
     * @return The number of matching child elements.
     */
    public static int getChildElementCountByTagName(Element parentElement, String name) {
        NodeList nodes = parentElement.getChildNodes();
        int length = nodes.getLength();
        int count = 0;
        for (int index = 0; index < length; ++index) {
            if (nodes.item(index).getNodeType() == Node.ELEMENT_NODE
                    && name.equals(nodes.item(index).getNodeName())) {
                ++count;
            }
        }
        return count;
    }
    
    /**
     * Returns the text content of a DOM <code>Element</code>.
     * 
     * @param element The <code>Element</code> to analyze.
     */
    public static String getElementText(Element element) {
        NodeList children = element.getChildNodes();
        int childCount = children.getLength();
        for (int index = 0; index < childCount; ++index) {
            if (children.item(index) instanceof Text) {
                Text text = (Text) children.item(index);
                return text.getData();
            }
        }
        return null;
    }

    /**
     * Returns a new DOM from an <code>InputStream</code>.
     * 
     * @param in an <code>InputStream</code> providing the XML source
     * @return a DOM
     */
    public static Document load(InputStream in) 
    throws SAXException {
        try {
            Document document = getDocumentBuilder().parse(in);
            in.close();
            return document;
        } catch (SAXException ex) {
            throw new SAXException("Provided InputStream cannot be parsed: " + ex.toString());
        } catch (IOException ex) {
            throw new SAXException("Provided InputStream cannot be parsed: " + ex.toString());
        }
    }
    
    public static void log(PrintStream out, String prefix, Document document) {
        out.println ("[" + prefix + "] --------------------------------------------------------");
		StringWriter w = new StringWriter();
		DomUtil.save(document, new PrintWriter(w), null);
		String s = w.toString();
		s = s.replaceAll(">\\s*<", ">\n<");
		out.println(s);
    }

    private static void save(Document document, PrintWriter printWriter,
			Object object) {
		// TODO Auto-generated method stub
		
	}

	/**
     * Returns a new DOM from an <code>InputStream</code>.
     * 
     * @param in an <code>InputStream</code> providing the XML source
     * @return a DOM
     */
    public static Document load(InputSource in) 
    throws SAXException {
        try {
            Document document = getDocumentBuilder().parse(in);
            return document;
        } catch (SAXException ex) {
            throw new SAXException("Provided InputStream cannot be parsed: " + ex.toString());
        } catch (IOException ex) {
            throw new SAXException("Provided InputStream cannot be parsed: " + ex.toString());
        }
    }
    
    /*
    public static void save(Document document, PrintWriter w, Properties outputProperties) 
    throws SAXException {
        DomTransform.transform(document, w);
    }
    */

    /**
     * Sets the text content of a DOM <code>Element</code>.
     * 
     * @param element The <code>Element</code> to modify.
     * @param value The new text value.
     */
    public static void setElementText(Element element, String value) {
        NodeList children = element.getChildNodes();
        int childCount = children.getLength();
        for (int index = 0; index < childCount; ++index) {
            if (children.item(index) instanceof Text) {
                Text text = (Text) children.item(index);
                text.setData(value);
                return;
            }
        }
        Text text = element.getOwnerDocument().createTextNode(value);
        element.appendChild(text);
    }
    
    public static Element setPropertyElementValue(Element parentElement, String propertyName, String propertyValue) {
        Element propertyElement = parentElement.getOwnerDocument().createElement(propertyName);
        if (propertyValue != null) {
            propertyElement.appendChild(parentElement.getOwnerDocument().createTextNode(propertyValue));
        }
        parentElement.appendChild(propertyElement);
        return propertyElement;
    }
    
    /** Non-instantiable class. */
    private DomUtil() { }
}
